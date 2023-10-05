using System.Diagnostics.CodeAnalysis;
using System.Diagnostics;

namespace Licenta.Sdk.Identity
{
    internal static class StringExtensions
    {
        [DebuggerStepThrough]
        public static bool IsMissing([NotNullWhen(false)] this string? value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        [DebuggerStepThrough]
        public static bool IsPresent([NotNullWhen(true)] this string? value)
        {
            return !string.IsNullOrWhiteSpace(value);
        }

    }
}
