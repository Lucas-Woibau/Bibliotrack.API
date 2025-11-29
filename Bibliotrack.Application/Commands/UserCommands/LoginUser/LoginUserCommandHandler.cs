using Bibliotrack.Application.Configurations;
using Bibliotrack.Application.Models;
using Bibliotrack.Application.Services;
using MediatR;

namespace Bibliotrack.Application.Commands.UserCommands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, ResultViewModel<LoginViewModel>>
    {
        private readonly IAuthService _authService;
        private readonly IAuthConfig _authConfig;

        public LoginUserCommandHandler(
            IAuthService authService,
            IAuthConfig authConfig)
        {
            _authService = authService;
            _authConfig = authConfig;
        }

        public async Task<ResultViewModel<LoginViewModel>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            if (request.Email != _authConfig.Email ||
                request.Password != _authConfig.Password)
            {
                return ResultViewModel<LoginViewModel>.Error("Invalid Credentials.");
            }

            var token = _authService.GenerateToken(request.Email, "Admin");
            return ResultViewModel<LoginViewModel>.Success(new LoginViewModel(token));
        }
    }
}

