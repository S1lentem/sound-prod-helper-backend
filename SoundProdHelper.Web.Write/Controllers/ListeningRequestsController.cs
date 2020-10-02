using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SoundProdHelper.Application.Write.Commands;
using SoundProdHelper.ServiceConfiguration;
using SoundProdHelper.Web.Write.Models;

namespace SoundProdHelper.Web.Write.Controllers
{
    public class ListeningRequestsController : WebApiControllerBase
    {
        public ListeningRequestsController(IMediator mediator) : base(mediator)
        {

        }

        [HttpPost]
        public async Task<IActionResult> AddListeningRequest([FromBody] NewListeningRequestModel model)
        {
            var command = new CreateListeningRequestCommand
            {
                DemoUid = model.DemoUid,
                LabelUId = model.LabelUid,
            };

            var result = await Mediator.Send(command).ConfigureAwait(false);

            return CreateResponse(result);
        }
    }
}