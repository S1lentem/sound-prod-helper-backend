using System.Threading.Tasks;

namespace SoundProdHelper.Crypto.Interfaces
{
    public interface IRSACryptoEngine
    {
        ((ulong, ulong), (ulong, ulong)) GenerateKeys(ulong? pVal = null, ulong? qVal = null);
        Task<((ulong, ulong), (ulong, ulong))> GenerateKeysAsync(ulong? pVal = null, ulong? qVal = null);
    }
}