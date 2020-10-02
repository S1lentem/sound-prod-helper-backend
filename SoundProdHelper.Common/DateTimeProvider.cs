using System;

namespace SoundProdHelper.Common
{
    public class DateTimeProvider
    {
        public DateTime UtcNow { get; }

        public DateTimeProvider()
        {
            UtcNow = DateTime.UtcNow;
        }
    }
}