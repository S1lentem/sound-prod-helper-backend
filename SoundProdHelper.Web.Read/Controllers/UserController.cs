using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SoundProdHelper.Application.Read.Queries.Users;
using SoundProdHelper.ServiceConfiguration;

namespace SoundProdHelper.Web.Read.Controllers
{
    public class UserController : WebApiControllerBase
    {
        public UserController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetUserByUid([FromQuery] GetUserByUidQuery query)
        {
            var result = await Mediator.Send(query).ConfigureAwait(false);

            return CreateResponse(result);
        }
    }
}