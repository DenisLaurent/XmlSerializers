using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Diagnostics;
using System.Text;
using System.Runtime.Serialization;
using System.Xml.Serialization;


namespace XmlDeserializersTestApp.Extensions
{


    public static class BaseExtensions
    {
        static string StreamToString(Stream stream)
        {
            stream.Position = 0;
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                return reader.ReadToEnd();
            }
        }


        public static string XmlReaderSerialize(this object obj)
        {
            XmlSerializer s = new XmlSerializer(obj.GetType(),"");
            MemoryStream ms = new MemoryStream();

            s.Serialize(ms, obj);
            return StreamToString(ms);
        }



        public static string XmlSerialize(this object obj)
        {
            DataContractSerializer s = new DataContractSerializer(obj.GetType());
            MemoryStream ms = new MemoryStream();
            s.WriteObject(ms, obj);
            return StreamToString(ms);
        }



    }
}
