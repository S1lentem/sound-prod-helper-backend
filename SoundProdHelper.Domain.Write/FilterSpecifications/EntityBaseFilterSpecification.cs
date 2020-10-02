using System;
using JetBrains.Annotations;
using SoundProdHelper.Domain.Base;
using SoundProdHelper.Domain.Specifications;

namespace SoundProdHelper.Domain.Write.FilterSpecifications
{
    public abstract class EntityBaseFilterSpecifications<T>
        where T: EntityBase
    {
        public class ByUid : FilterSpecificationBase<T>
        {
            public ByUid(Guid uid)
            {
                Predicate = entity => entity.Uid == uid;
            }
        }
    }
}