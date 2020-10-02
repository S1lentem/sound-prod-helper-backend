using Microsoft.AspNetCore.Mvc;
using SoundProdHelper.ApiGateway.Interfaces;
using SoundProdHelper.ApiGateway.Models;
using SoundProdHelper.Common.Extensions;
using System.Threading.Tasks;

namespace SoundProdHelper.ApiGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IAppCoreService _appCoreService;

        public AccountController(
            IAccountService accountService,
            IAppCoreService appCoreService) 
        {
            _accountService = accountService.ThrowIfNull(nameof(accountService));
            _appCoreService = appCoreService.ThrowIfNull(nameof(appCoreService));
        }

        [HttpPost("sign-up")]
        public async Task<IActionResult> SignIn([FromBody]SignUpModel model)
        {
            var accountIdentifier = await _accountService.CreateAccountAsync(model).ConfigureAwait(false);
            var errorMessages = await _appCoreService.CreateUserAsync(model, accountIdentifier).ConfigureAwait(false);

            return string.IsNullOrEmpty(errorMessages)
                ? Ok()
                : BadRequest(errorMessages) as IActionResult;
        }

        [HttpPost("sign-in")]
        public async Task<IActionResult> SingUp([FromBody]SignInModel model)
        {
            var userUid = await _accountService.AuthenticateAsync(model)
                .ConfigureAwait(false);

            if (userUid != null)
            {
                var user = await _appCoreService.GetUserAsync(userUid.Value)
                    .ConfigureAwait(false);
                return Ok(user);
            }

            return BadRequest();
        }
    }
}