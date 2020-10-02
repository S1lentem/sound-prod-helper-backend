using System;
using SoundProdHelper.Domain.Specifications;
using SoundProdHelper.Domain.Write.Entities;

namespace SoundProdHelper.Domain.Write.FilterSpecifications
{
    public class LabelFilterSpecifications : EntityBaseFilterSpecifications<Label>
    {
        public class ByName : FilterSpecificationBase<Label>
        {
            public ByName(string name)
            {
                Predicate = label => label.Name == name;
            }
        }

        public class ByOwnerUid : FilterSpecificationBase<Label>
        {
            public ByOwnerUid(Guid ownerUid)
            {
                Predicate = label => label.OwnerUid == ownerUid;
            }
        }
    }
}