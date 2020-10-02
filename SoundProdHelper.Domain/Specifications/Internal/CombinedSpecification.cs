using System;
using System.Linq.Expressions;
using SoundProdHelper.Domain.Base;

namespace SoundProdHelper.Domain.Specifications.Internal
{
    internal class CombinedSpecification<T> : FilterSpecificationBase<T>
        where T: EntityBase
    {
        public CombinedSpecification(Expression<Func<T, bool>> predicate)
        {
            Predicate = predicate ?? throw new ArgumentNullException(nameof(predicate));
        }
    }
}