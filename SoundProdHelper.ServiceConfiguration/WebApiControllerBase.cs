using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SoundProdHelper.Common.Extensions;
using SoundProdHelper.Domain;

namespace SoundProdHelper.ServiceConfiguration
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class WebApiControllerBase : ControllerBase
    {
        protected readonly IMediator Mediator;

        protected WebApiControllerBase(IMediator mediator)
        {
            Mediator = mediator.ThrowIfNull(nameof(mediator));
        }
        
        protected IActionResult CreateResponse<T>(ResultOf<T> result, Func<T, object> map = null)
        {
            if (!result.IsSuccess)
            {
                return BadRequest(result.ErrorDescription);
            }

            var response = map?.Invoke(result.Value) ?? result.Value;

            return Ok(response);

        }
    }
}