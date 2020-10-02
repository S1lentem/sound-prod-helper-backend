using System;

namespace SoundProdHelper.Application.Read.Dto
{
    public class UserDto
    {
        public Guid Uid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
    }
}