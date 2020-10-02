using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SoundProdHelper.Application.Write.Commands;
using SoundProdHelper.ServiceConfiguration;
using SoundProdHelper.Web.Write.Models;

namespace SoundProdHelper.Web.Write.Controllers
{
    public class LabelController : WebApiControllerBase
    {
        public LabelController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> CreateLabel([FromBody] NewLabelModel newLabel)
        {
            // TODO Add User Uid
            var command = new CreateLabelCommand
            {
                Name = newLabel.Title,
            };

            var result = await Mediator.Send(command).ConfigureAwait(false);

            return CreateResponse(result);
        }
    }
}