using Ardalis.GuardClauses;

namespace SoundProdHelper.Common.Extensions
{
    public static class CommonExtensions
    {
        public static T ThrowIfNull<T>(this T self, string paramName)
        {
            Guard.Against.Null(self, paramName);

            return self;
        }

        public static string ThrowIfNullOrEmpty(this string self, string paramName)
        {
            Guard.Against.NullOrEmpty(self.Trim(), paramName);

            return self;
        }
    }
}