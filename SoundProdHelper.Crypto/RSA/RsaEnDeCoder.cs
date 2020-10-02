using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SoundProdHelper.Crypto.Interfaces;

namespace SoundProdHelper.Crypto.RSA
{
    public class RsaEnDeCoder : IEnDeCoder
    {
        public IEnumerable<int> Encode(string value, (int, int) key)
        {
            var (e, n) = key;
            var bytes = Encoding.UTF8.GetBytes(value);

            return bytes.Select(Convert.ToInt32)
                .Select(i => Math.Pow(i, e) % n)
                .Select(i => (int) i);
        }

        public string Decode(IEnumerable<int> value, (int, int) key)
        {
            var (d, n) = key;
            var bytes = value.Select(i => Math.Pow(i, d) % n)
                .Select(Convert.ToByte)
                .ToArray();

            return Encoding.UTF8.GetString(bytes);
        }
    }
}