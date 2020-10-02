using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using SoundProdHelper.Common;
using SoundProdHelper.Common.Extensions;
using SoundProdHelper.Domain.Contracts;

namespace SoundProdHelper.Common.CQRS
{
    public abstract class CommandHandlerBase<TRequest, TResponse> : IRequestHandler<TRequest, ResultOf<TResponse>>
        where TRequest : IRequest<ResultOf<TResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEnumerable<IValidator<TRequest>> _validators;

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
    }
}