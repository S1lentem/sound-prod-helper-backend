using System;
using SoundProdHelper.Domain.Read.Entities;
using SoundProdHelper.Domain.Specifications;

namespace SoundProdHelper.Domain.Read.Specifications
{
    public class UserFilterSpecifications 
    {
        public class ByUid : FilterSpecificationBase<User> 
        {
            public ByUid(Guid uid)
            {
                Predicate = user => user.Uid == uid;
            }   
        }
    }
}