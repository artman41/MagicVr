using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts {
    public static class ListExtensions {
        public static string ToString<T>(this List<T> x, bool b) {
            string a = string.Empty;
            for (int i = 0; i < x.Count; i++) {
                if (i != x.Count) {
                    a += x[i].ToString() + ", ";
                } else {
                    a += x[i].ToString();
                }
            }
            return a;
        }
    }
}
