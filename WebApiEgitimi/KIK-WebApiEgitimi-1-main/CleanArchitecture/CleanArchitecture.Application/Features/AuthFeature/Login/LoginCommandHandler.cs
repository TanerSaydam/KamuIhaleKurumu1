using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories;
using MediatR;

namespace CleanArchitecture.Application.Features.AuthFeature.Login;

public sealed class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponseDto>
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtProvider _jwtProvider;
    public LoginCommandHandler(IUserRepository userRepository, IJwtProvider jwtProvider)
    {
        _userRepository = userRepository;
        _jwtProvider = jwtProvider;
    }

    public async Task<LoginResponseDto> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        //User user = await _userRepository.GetByExpressionAsync(p=> p.UserName == request.UserName);

        //if(user == null)
        //{
        //    throw new Exception("Kullanıcı bulunamadı!");
        //}

        User user = new()
        {
            Id = Guid.NewGuid(),
            UserName = "tanersaydam"
        };

        LoginResponseDto response = await _jwtProvider.CreateTokenAsync(user, new List<Role>(), cancellationToken);

        return response;
    }
}
