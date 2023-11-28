using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Exceptions;
using CleanArchitecture.Domain.Repositories;
using Elasticsearch.Net;
using GenericRepository;
using MediatR;

namespace CleanArchitecture.Application.Features.ProductFeature.Commands.CreateProduct;

internal sealed class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ResponseDto>
{
    private readonly IProductRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateProductCommandHandler(IProductRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        Product product = await _repository.GetByExpressionAsync(p => p.Name == request.Name);

        if(product != null)
        {
            throw new AlreadyExistException();
        }

        product = new()
        {
            Name = request.Name,
            Price = request.Price,
        };

        await _repository.AddAsync(product, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);


        var setting = new ConnectionConfiguration(new Uri("http://localhost:9200"));
        var client = new ElasticLowLevelClient(setting);

        await client.IndexAsync<StringResponse>("products",product.Id.ToString(),PostData.Serializable(product));


        return new("Kayıt işlemi başarılı");
    }
}
