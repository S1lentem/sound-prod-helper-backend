using SoundProdHelper.Domain.Base;

namespace SoundProdHelper.UserService.Domain.Entities
{
    public class User : EntityBase
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}