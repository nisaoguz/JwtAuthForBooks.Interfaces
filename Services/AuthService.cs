/*
using JwtAuthForBooks.Interfaces;
using JwtAuthForBooks.Models;

namespace JwtAuthForBooks.Services
{
    public class AuthService : IAuthService
    {
        private readonly ITokenService _tokenService;

        public AuthService(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        public async Task<UserLoginResponse> LoginUserAsync(UserLoginRequest request)
        {
            UserLoginResponse response = new();

            if (string.IsNullOrEmpty(request.UserName) || string.IsNullOrEmpty(request.Password))
            {
                throw new ArgumentNullException(nameof(request));
            }

            if (request.UserName == "nisa" && request.Password == "123456")
            {
                var generatedTokenInformation = await _tokenService.GenerateToken(new GenerateTokenRequest { Username = request.Username });

                response.AuthenticateResult = true;
                response.AuthToken = generatedTokenInformation.AccessToken;
                response.AccessTokenExpireDate = generatedTokenInformation.AccessTokenExpireDate;
                response.RefreshToken = generatedTokenInformation.RefreshToken;
            }

            return response;
        }
    }
}
*/


/*
using JwtAuthForBooks.IdentityModels;
using JwtAuthForBooks.Interfaces;
using JwtAuthForBooks.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace JwtAuthForBooks.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<LoginModel> _userManager;
        private readonly SignInManager<LoginModel> _signInManager;
        private readonly ITokenService _tokenService;

        public AuthService(UserManager<LoginModel> userManager, SignInManager<LoginModel> signInManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public async Task<UserLoginResponse> LoginUserAsync(UserLoginRequest request)
        {
            UserLoginResponse response = new();

            if (string.IsNullOrEmpty(request.UserName) || string.IsNullOrEmpty(request.Password))
            {
                throw new ArgumentNullException(nameof(request));
            }


            var user = await _userManager.FindByNameAsync(request.UserName);

            if (user != null)
            {
                var signInResult = await _signInManager.PasswordSignInAsync(user, request.Password, isPersistent: false, lockoutOnFailure: false);

                if (signInResult.Succeeded)
                {
                    var generatedTokenInformation = await _tokenService.GenerateToken(new GenerateTokenRequest { UserName = request.UserName });

                    response.AuthenticateResult = true;
                    response.AuthToken = generatedTokenInformation.AccessToken;
                    response.AccessTokenExpireDate = generatedTokenInformation.AccessTokenExpireDate;
                    response.RefreshToken = generatedTokenInformation.RefreshToken;
                }
            }

            return response;
        }
    }
}
*/