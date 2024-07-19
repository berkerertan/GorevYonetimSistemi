using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GorevYonetimSistemi.Core.Utilities.Helpers
{
    public static class EnumHelper
    {
        public static List<string> GetEnumDescriptions<T>() where T : Enum
        {
            return Enum.GetValues(typeof(T)).Cast<T>().Select(e => e.ToString()).ToList();
        }
    }
}
