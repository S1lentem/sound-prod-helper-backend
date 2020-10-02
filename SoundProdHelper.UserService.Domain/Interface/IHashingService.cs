namespace SoundProdHelper.UserService.Domain.Interface
{
    public interface IHashingService
    {
        string CreateHash(string input);
        bool VerifyHash(string input, string expectedResult);
    }
}