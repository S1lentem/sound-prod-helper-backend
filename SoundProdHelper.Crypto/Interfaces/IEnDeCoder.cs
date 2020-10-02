using System.Collections.Generic;

namespace SoundProdHelper.Crypto.Interfaces
{
    public interface IEnDeCoder
    {
        public IEnumerable<int> Encode(string value, (int, int) key);
        public string Decode(IEnumerable<int> value, (int, int) key);
    }
}