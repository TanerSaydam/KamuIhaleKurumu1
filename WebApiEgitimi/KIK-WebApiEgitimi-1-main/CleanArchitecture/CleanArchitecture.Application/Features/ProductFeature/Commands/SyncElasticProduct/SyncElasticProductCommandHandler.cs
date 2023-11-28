using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories;
using Elasticsearch.Net;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Features.ProductFeature.Commands.SyncElasticProduct;

public sealed class SyncElasticProductCommandHandler : IRequestHandler<SyncElasticProductCommand, ResponseDto>
{
    private readonly IProductRepository _repository;

    public SyncElasticProductCommandHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<ResponseDto> Handle(SyncElasticProductCommand request, CancellationToken cancellationToken)
    {
        List<Product> products = await _repository.GetAll().ToListAsync(cancellationToken);

        var setting = new ConnectionConfiguration(new Uri("http://localhost:9200"));
        var client = new ElasticLowLevelClient(setting);

        var tasks = new List<Task>();

        foreach (var product in products)
        {
            var response = await client.GetAsync<StringResponse>("products", product.Id.ToString());

            if (response.HttpStatusCode != 200)
            {
                tasks.Add(client.IndexAsync<StringResponse>("products", product.Id.ToString(), PostData.Serializable(product)));
            }
        }

        await Task.WhenAll(tasks);


        return new("Aktarma işlemi başarılı");
    }
}
