using System.Collections.Generic;
using System.Linq;

namespace SoundProdHelper.Common.Extensions
{
    public static class CollectionExtensions
    {
        public static bool IsOneOf<T>(this T self, params T[] items)
        {
            return items.Contains(self);
        }
    }
}