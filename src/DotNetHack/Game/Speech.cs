using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DotNetHack.Game
{
    /// <summary>
    /// Speech
    /// </summary>
    public static class Speech
    {
        /// <summary>
        /// Pluralize
        /// </summary>
        /// <param name="s">The singular form of a word</param>
        /// <param name="count">The number of "things" in question.</param>
        /// <returns>The plural form of the word.</returns>
        public static string Pluralize(this string s, int count)
        {
            return Pluralizer.Pluralize(count, s);
        }

        /// <summary>
        /// <see cref="http://mattgrande.wordpress.com/2009/10/28/pluralization-helper-for-c/"/>
        /// </summary>
        public static class Pluralizer
        {
            /// <summary>
            /// Unpluralizables
            /// </summary>
            private static readonly ISet<string> Unpluralizables = new HashSet<string> 
            { "equipment", "information", "rice", "money", "species", "series", 
                "fish", "sheep", "deer" };

            /// <summary>
            /// Pluralizations RegEx Dictionary
            /// </summary>
            private static readonly IDictionary<string, string> Pluralizations = new Dictionary<string, string>()
            {
                // Start with the rarest cases, and move to the most common
                { "person", "people" },
                { "ox", "oxen" },
                { "child", "children" },
                { "foot", "feet" },
                { "tooth", "teeth" },
                { "goose", "geese" },
                // And now the more standard rules.
                { "(.*)fe?", "$1ves" },         // ie, wolf, wife
                { "(.*)man$", "$1men" },
                { "(.+[aeiou]y)$", "$1s" },
                { "(.+[^aeiou])y$", "$1ies" },
                { "(.+z)$", "$1zes" },
                { "([m|l])ouse$", "$1ice" },
                { "(.+)(e|i)x$", @"$1ices"},    // ie, Matrix, Index
                { "(octop|vir)us$", "$1i"},
                { "(.+(s|x|sh|ch))$", @"$1es"},
                { "(.+)", @"$1s" }
            };

            /// <summary>
            /// Pluralize
            /// </summary>
            /// <param name="count">The number</param>
            /// <param name="singular">The singlular form of the word.</param>
            /// <returns>A string containing the plural form of the word.</returns>
            public static string Pluralize(int count, string singular)
            {
                if (count == 1)
                    return singular;

                if (Unpluralizables.Contains(singular))
                    return singular;

                var plural = "";

                foreach (var pluralization in Pluralizations)
                    if (Regex.IsMatch(singular, pluralization.Key))
                    {
                        plural = Regex.Replace(singular,
                            pluralization.Key, pluralization.Value);
                        break;
                    }

                return plural;
            }
        }
    }
}
