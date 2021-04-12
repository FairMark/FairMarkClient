using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairMark.Toolbox
{
    internal static class StringExtensions
    {
        /// <summary>
        /// Appends the given suffix if it's missing.
        /// </summary>
        /// <param name="str">The string to append to.</param>
        /// <param name="suffix">The suffix.</param>
        /// <param name="comparison">Optional comparison type.</param>
        public static string AppendMissing(this string str, string suffix, StringComparison comparison = StringComparison.InvariantCulture)
        {
            if (str.EndsWith(suffix, comparison))
            {
                return str;
            }

            return str + suffix;
        }
    }
}
