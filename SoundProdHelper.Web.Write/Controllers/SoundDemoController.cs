using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SoundProdHelper.Application.Write.Commands;
using SoundProdHelper.ServiceConfiguration;
using SoundProdHelper.Web.Write.Models;

namespace SoundProdHelper.Web.Write.Controllers
{
    public class SoundDemoController : WebApiControllerBase
    {
        public SoundDemoController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> AddDemo([FromBody] NewDemoModel model)
        {
            //TODO Add file saving
            
            var command = new AddSoundDemoCommand
            {
                Title = model.Title,
                Description = model.Description,
                //TODO Add more information
            };

            var result = await Mediator.Send(command);

            return CreateResponse(result);
        }
    }
}