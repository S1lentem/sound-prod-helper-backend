using SoundProdHelper.ApiGateway.Models;
using System;
using System.Threading.Tasks;

namespace SoundProdHelper.ApiGateway.Interfaces
{
    public interface IAccountService
    {
        Task<Guid> CreateAccountAsync(SignUpModel newAccountModel);
        Task<Guid?> AuthenticateAsync(SignInModel signInModel);
    }
}
