using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts {
    public static class StringExtensions {

        /// <summary>
        /// Converts a "String Array" (a, b, c, d) into an array
        /// </summary>
        /// <param name="s">input string</param>
        /// <param name="b">remove whitespace?</param>
        /// <returns></returns>
        public static string[] ToArray(this string s, bool b) {
            return s.ToArray(',', b);
        }

        /// <summary>
        /// Converts a "String Array" (a, b, c, d) into an array
        /// </summary>
        /// <param name="s">input string</param>
        /// <param name="c">char to split on</param>
        /// <param name="b">remove whitespace?</param>
        /// <returns></returns>
        public static string[] ToArray(this string s, char c, bool b) {
            string[] sa = s.Split(c);
            if (b) {
                for (int i = 0; i < sa.Length; i++) {
                    sa[i] = sa[i].Replace(" ", "");
                }
            } else {
                if(sa[sa.Length-1].ToCharArray()[sa.Length-1] == ' ') {
                    sa[sa.Length - 1] = sa[sa.Length - 1].Substring(sa[sa.Length - 1].Length - 1);
                }
            }
            return sa;
        }

    }
}
