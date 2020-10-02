using SoundProdHelper.Domain.Specifications;
using SoundProdHelper.UserService.Domain.Entities;

namespace SoundProdHelper.UserService.Domain.Specifications.UserSpecs
{
    public class UserFilteringSpecs
    {
        public class ByEmail : FilterSpecificationBase<User>
        {
            public ByEmail(string email)
            {
                Predicate = user => user.Email == email;
            }
        }
    }
}