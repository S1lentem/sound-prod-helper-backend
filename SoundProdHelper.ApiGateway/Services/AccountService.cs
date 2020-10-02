using AutoMapper;
using SoundProdHelper.ApiGateway.Models;
using SoundProdHelper.Common.Extensions;
using System;
using System.Threading.Tasks;
using SoundProdHelper.ApiGateway.Interfaces;
using SoundProdHelper.Protos.UserProtoModels;

namespace SoundProdHelper.ApiGateway.Services
{
    public class AccountService : IAccountService
    {
        

        /*private readonly IMapper _mapper;

        public AccountService(
            AccountWebService.AccountWebServiceClient accountWebServiceClient,
            IMapper mapper)
        {
            _accountWebServiceClient = accountWebServiceClient.ThrowIfNull(nameof(accountWebServiceClient));
            _mapper = mapper.ThrowIfNull(nameof(mapper));
        }

        public async Task<Guid> CreateAccountAsync(SignUpModel newAccountModel)
        {
            var request = _mapper.Map<CreateAccountRequest>(newAccountModel);

            var accountServiceResponse = await _accountWebServiceClient.CreateAccountAsync(request);

            return new Guid(accountServiceResponse.AccountIndetifier);
        }


        public async Task<Guid> AuthenticateAsync(SignInModel signInModel)
        {
            var request = _mapper.Map<AuthenticateRequest>(signInModel);

            var userInfo = await _accountWebServiceClient.AuthnticateAsync(request);

            return new Guid(userInfo.AccountIndetifier);
        }*/
        public Task<Guid> CreateAccountAsync(SignUpModel newAccountModel)
        {
            throw new NotImplementedException();
        }

        public Task<Guid?> AuthenticateAsync(SignInModel signInModel)
        {
            throw new NotImplementedException();
        }
    }
}
