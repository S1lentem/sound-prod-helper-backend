using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using SoundProdHelper.Common.Extensions;

namespace SoundProdHelper.Common.CQRS
{
    public abstract class QueryHandlerBase<TRequest, TResponse> : IRequestHandler<TRequest, ResultOf<TResponse>>
        where TRequest : IRequest<ResultOf<TResponse>>
    {
        protected readonly IMapper Mapper;
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        protected QueryHandlerBase(IMapper mapper, IEnumerable<IValidator<TRequest>> validators)
        {
            Mapper = mapper.ThrowIfNull(nameof(mapper));
            _validators = validators.ThrowIfNull(nameof(validators));
        }

        public async Task<ResultOf<TResponse>> Handle(TRequest request, CancellationToken cancellationToken)
        {
            var validationFails = _validators.Select(i => i.Validate(request))
                .Where(i => !i.IsValid)
                .SelectMany(i => i.Errors)
                .Select(i => i.ErrorMessage)
                .ToArray();

            if (validationFails.Any())
            {
                var errorMessage = string.Join("\n", validationFails);
                return ResultOf<TResponse>.BadRequest(errorMessage);
            }

            var queryResult = await ProcessQueryAsync(request, cancellationToken)
                .ConfigureAwait(false);

            return ResultOf<TResponse>.Ok(queryResult);
        }

        protected abstract Task<TResponse> ProcessQueryAsync(TRequest request, CancellationToken cancellationToken);
    }
}