using System;
using System.Security.Cryptography;
using SoundProdHelper.Crypto.Interfaces;

namespace SoundProdHelper.Crypto
{
    public class HashManager : IHashManager
    {
        public string GetHash(string value)
        {
            using var bytes = new Rfc2898DeriveBytes(value, 0x10, 0x3e8);

            var buffer = bytes.GetBytes(0x20);
            var dist = new byte[0x31];

            Buffer.BlockCopy(bytes.Salt, 0, dist, 1, 0x10);
            Buffer.BlockCopy(buffer, 0, dist, 0x11, 0x20);

            return Convert.ToBase64String(dist);
        }

        public bool VerifyHash(string hash, string value)
        {
            var src = Convert.FromBase64String(hash);

            if (src.Length != 0x31 || src[0] != 0)
            {
                return false;
            }

            var dist = new byte[0x10];
            var buffer3 = new byte[0x20];

            Buffer.BlockCopy(src, 1, dist, 0, 0x10);
            Buffer.BlockCopy(src, 0x11, buffer3, 0, 0x20);

            using var bytes = new Rfc2898DeriveBytes(value, dist, 0x3e8);
            var buffer = bytes.GetBytes(0x20);

            if (buffer.Length != buffer3.Length)
            {
                return false;
            }

            for (var i = 0; i < buffer.Length; i++)
            {
                if (buffer[i] != buffer3[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
