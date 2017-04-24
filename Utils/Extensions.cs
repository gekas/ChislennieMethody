using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public static class Extensions
    {
        public static string ToShortString(this double d)
        {
            return d.ToString("#.#####");
        }
    }
}
