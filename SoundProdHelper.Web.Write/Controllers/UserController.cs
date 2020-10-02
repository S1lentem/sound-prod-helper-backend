using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SoundProdHelper.Application.Write.Commands;
using SoundProdHelper.ServiceConfiguration;

namespace SoundProdHelper.Web.Write.Controllers
{
    public class UserController : WebApiControllerBase
    {
        public UserController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserAsync([FromBody] CreateUserCommand command)
        {
            var result = await Mediator.Send(command).ConfigureAwait(false);

            return CreateResponse(result);
        }
    }
}