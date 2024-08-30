/*

using JwtAuthForBooks.Interfaces;
using JwtAuthForBooks.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace JwtAuthForBooks.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Task<GenerateTokenResponse> GenerateToken(GenerateTokenRequest request)
        {
            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AppSettings:Secret"]));

            var dateTimeNow = DateTime.UtcNow;

            JwtSecurityToken jwt = new JwtSecurityToken(
                issuer: _configuration["AppSettings:ValidIssuer"],
                audience: _configuration["AppSettings:ValidAudience"],
                claims: new List<Claim> {
                    new Claim("userName", request.UserName)
                },
                notBefore: dateTimeNow,
                expires: dateTimeNow.Add(TimeSpan.FromMinutes(120)), // Access token'ın geçerlilik süresi
                signingCredentials: new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256)
            );

            string accessToken = new JwtSecurityTokenHandler().WriteToken(jwt);



            // Refresh token oluştur (6 ay geçerli)
            string refreshToken = GenerateRefreshToken();

            return Task.FromResult(new GenerateTokenResponse
            {
                AccessToken = accessToken,
                AccessTokenExpireDate = jwt.ValidTo,
                RefreshToken = refreshToken
            });
        }

        private string GenerateRefreshToken()
        {
            const int tokenLength = 32; // Refresh token uzunluğu (byte cinsinden)

            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] tokenBytes = new byte[tokenLength];
                rng.GetBytes(tokenBytes);

                return Convert.ToBase64String(tokenBytes);
            }
        }
    }
}
*/