namespace SoundProdHelper.Crypto.Extensions
{
    public static class NumberExtensions
    {
        public static bool IsPrime(this int self)
        {
            var d = 2;

            while (d * d <= self && self % d != 0)
            {
                d += 1;
            }

            return d * d > self;
        }

        public static bool IsPrime(this ulong self)
        {
            ulong d = 2;

            while (d * d <= self && self % d != 0)
            {
                d += 1;
            }

            return d * d > self;
        }
    }
}