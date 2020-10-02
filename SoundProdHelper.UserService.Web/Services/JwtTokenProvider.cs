using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using SoundProdHelper.Common.Extensions;
using SoundProdHelper.UserService.Domain.Entities;

namespace SoundProdHelper.UserService.Web.Services
{
    public class JwtTokenProvider
    {
        private const string FirstPrivateKeyTypeName = "FirstPrivateKey";
        private const string SecondPrivateKeyTypeName = "SecondPrivateKey";

        private readonly byte[] _key;

        public JwtTokenProvider(string key)
        {
            key = key.ThrowIfNull(nameof(key));
            _key = Encoding.ASCII.GetBytes(key);
        }

        public string GenerateToken(CryptoKeys keys)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var claims = new[]
            {
                new Claim(FirstPrivateKeyTypeName, keys.FirstPartPrivateKey.ToString()),
                new Claim(SecondPrivateKeyTypeName, keys.SecondPartPrivateKey.ToString()),
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(_key), SecurityAlgorithms.HmacSha256Signature),
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}