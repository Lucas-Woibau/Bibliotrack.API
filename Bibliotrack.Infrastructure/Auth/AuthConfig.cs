using Bibliotrack.Application.Configurations;
using Microsoft.Extensions.Options;

namespace Bibliotrack.Infrastructure.Auth
{
    public class AuthConfig : IAuthConfig
    {
        private readonly AuthSettings _settings;

        public AuthConfig(IOptions<AuthSettings> settings)
        {
            _settings = settings.Value;
        }

        public string Email => _settings.Email;
        public string Password => _settings.Password;
    }
}
