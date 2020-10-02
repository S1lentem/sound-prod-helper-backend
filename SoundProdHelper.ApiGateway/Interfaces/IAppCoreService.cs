using SoundProdHelper.ApiGateway.Models;
using System;
using System.Threading.Tasks;

namespace SoundProdHelper.ApiGateway.Interfaces
{
    public interface IAppCoreService
    {
        Task<string> CreateUserAsync(SignUpModel model, Guid AccountIdentifier);
        Task<dynamic> GetUserAsync(Guid uid);
    }
}
