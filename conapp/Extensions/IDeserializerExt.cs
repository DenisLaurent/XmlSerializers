using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlDeserializersTestApp.Extensions
{

    public static class IDeserializerExt
    {
        public static string GetName<T>(this IDeserializer<T> src)
        {
            return src.GetType().Name;
        }
    }
}
