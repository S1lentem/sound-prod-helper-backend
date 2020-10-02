using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SoundProdHelper.Common.Extensions;
using SoundProdHelper.ServiceConfiguration;
using SoundProdHelper.UserService.Application.Command;
using SoundProdHelper.UserService.Domain.Entities;
using SoundProdHelper.UserService.Web.Services;

namespace SoundProdHelper.UserService.Web.Controllers
{
    public class AuthenticationController : WebApiControllerBase
    {
        private readonly JwtTokenProvider _jwtTokenProvider;

        public AuthenticationController(IMediator mediator, JwtTokenProvider jwtTokenProvider) : base(mediator)
        {
            _jwtTokenProvider = jwtTokenProvider.ThrowIfNull(nameof(jwtTokenProvider));
        }


        [HttpPost]
        public async Task<IActionResult> Authenticate([FromBody]AuthenticateCommand command)
        {
            var authResult = await Mediator.Send(command).ConfigureAwait(false);

            if (!authResult.IsSuccess)
            {
                return BadRequest(authResult.ErrorDescription);
            }

            var cryptoKeys = new CryptoKeys
            {
                FirstPartPrivateKey = authResult.Value.PrivateKey.Item1,
                SecondPartPrivateKey = authResult.Value.PrivateKey.Item2,

            };
            var token = _jwtTokenProvider.GenerateToken(cryptoKeys);
            return null;
        }
    }
}