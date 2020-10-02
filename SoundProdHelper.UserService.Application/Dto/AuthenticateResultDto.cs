using System;

namespace SoundProdHelper.UserService.Application.Dto
{
    public class AuthenticateResultDto 
    {
        public Guid UserUid { get; set; }
        public (ulong, ulong) PublicKey { get; set; }
        public (ulong, ulong) PrivateKey { get; set; }
    }
}