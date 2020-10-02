using System;
using System.Threading.Tasks;
using SoundProdHelper.Crypto.Extensions;
using SoundProdHelper.Crypto.Interfaces;

namespace SoundProdHelper.Crypto.RSA
{
    public class RsaEngine : IRSACryptoEngine
    {
        private const int DefaultP = 53;
        private const int DefaultQ = 61;


        public ((ulong, ulong), (ulong, ulong)) GenerateKeys(ulong? pVal = null, ulong? qVal = null)
        {
            var p = pVal ?? DefaultP;
            var q = qVal ?? DefaultQ;

            var n = p * q;
            var f = (p - 1) * (q - 1);
            
            var e = f - 1;
            while (e > 0)
            {
                if (e.IsPrime() && f % e == 0)
                {
                    break;
                }

                e -= 1;
            }

            var d = Math.Max(p, q) / 2;

            while ((d * e) % f != 1)
            {
                d += 1;
            }

            return ((e, n), (d, n));
        }

        public Task<((ulong, ulong), (ulong, ulong))> GenerateKeysAsync(ulong? pVal = null, ulong? qVal = null)
        {
            var task = new Task<((ulong, ulong), (ulong, ulong))>(() => GenerateKeys(pVal, qVal));
            task.Start();

            return task;
        }
    }
}