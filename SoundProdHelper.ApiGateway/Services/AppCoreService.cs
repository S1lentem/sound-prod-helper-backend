using System;
using System.Threading.Tasks;
using SoundProdHelper.ApiGateway.Interfaces;
using SoundProdHelper.ApiGateway.Models;

namespace SoundProdHelper.ApiGateway.Services
{
    public class AppCoreService : IAppCoreService
    {
        /*private readonly AppCoreWebService.AppCoreWebServiceClient _appCoreWebServiceClient;
        private readonly IMapper _mapper;

        public AppCoreService(
            IMapper mapper, 
            AppCoreWebService.AppCoreWebServiceClient appCoreWebServiceClient)
        {
            _appCoreWebServiceClient = appCoreWebServiceClient.ThrowIfNull(nameof(appCoreWebServiceClient));
            _mapper = mapper.ThrowIfNull(nameof(mapper));
        }

        public async Task<string> CreateUserAsync(SignUpModel signUpModel)
        {
            var userRequest = new CreateUserRequest
            {
                FirstName = signUpModel.FirstName,
                LastName = signUpModel.LastName, 
                NickName = signUpModel.NickName, 
            };

            var response = await _appCoreWebServiceClient.CreateNewUserAsync(userRequest);

            return response.Errors;*/
        public Task<string> CreateUserAsync(SignUpModel model, Guid AccountIdentifier)
        {
            throw new NotImplementedException();
        }

        public Task<dynamic> GetUserAsync(Guid uid)
        {
            throw new NotImplementedException();
        }
    }
}

