using System;
using System.Collections.Generic;
using System.Text;

namespace DonationStore.Infrastructure.Extensions
{
    public static class StringExtensions
    {
        public static bool IsEmpty(this string value) => string.IsNullOrWhiteSpace(value);
    }
}
