using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using SoundProdHelper.Common.Extensions;
using SoundProdHelper.Domain.Contracts;

namespace SoundProdHelper.Domain.Base
{
    public abstract class CommandHandlerBase<TRequest, TResponse> : IRequestHandler<TRequest, ResultOf<TResponse>>
        where TRequest : IRequest<ResultOf<TResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        
        private  IList<string> _fails;

        protected CommandHandlerBase(
            IUnitOfWork unitOfWork,
            IEnumerable<IValidator<TRequest>> validators)
        {
            _unitOfWork = unitOfWork.ThrowIfNull(nameof(unitOfWork));
            _validators = validators.ThrowIfNull(nameof(validators));
        }

        public async Task<ResultOf<TResponse>> Handle(TRequest request, CancellationToken cancellationToken)
        {
            var validationFailMessages = _validators.Select(i => i.Validate(request))
                .SelectMany(i => i.Errors)
                .Select(i => i.ErrorMessage)
                .ToArray();

            if (validationFailMessages.Any())
            {
                var errors = string.Join("\n", validationFailMessages);
                return ResultOf<TResponse>.BadRequest(errors);
            }

            var result = await ProcessActionAsync(request, cancellationToken)
                .ConfigureAwait(false);

            if (_fails?.Any() ?? false)
            {
                var errors = string.Join("\n", _fails);
                return ResultOf<TResponse>.BadRequest(errors);
            }

            await _unitOfWork.CommitAsync().ConfigureAwait(false);

            // TODO Remove await, because do not need wait call end
            await PublishResultAsync(request, result);

            return ResultOf<TResponse>.Ok(result);
        }

        protected abstract Task<TResponse> ProcessActionAsync(TRequest request, CancellationToken cancellationToken);

        protected virtual Task PublishResultAsync(TRequest request, TResponse response)
        {
            return Task.CompletedTask;
        }

        protected void AddCommandFail(string reason)
        {
            _fails ??= new List<string>();
            _fails.Add(reason);
        }
    }
}