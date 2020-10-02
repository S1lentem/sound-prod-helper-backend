namespace SoundProdHelper.Crypto.Interfaces
{
    public interface IHashManager
    {
        string GetHash(string value);
        bool VerifyHash(string hash, string value);
    }
}
