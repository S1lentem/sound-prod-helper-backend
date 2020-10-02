using SoundProdHelper.Domain.Specifications;
using SoundProdHelper.Domain.Write.Entities;

namespace SoundProdHelper.Domain.Write.FilterSpecifications
{
    public class UserFilterSpecificationses : EntityBaseFilterSpecifications<User>
    {
        public class ByNickname : FilterSpecificationBase<User>
        {
            public ByNickname(string nickname)
            {
                Predicate = user => user.NickName == nickname;
            }
        }
    }
}