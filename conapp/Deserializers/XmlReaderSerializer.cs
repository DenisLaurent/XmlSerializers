using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace XmlDeserializersTestApp.Deserializers
{

    public class XmlReaderSerializer : IDeserializer<List<AccountAddedEventData>>
    {
        public List<AccountAddedEventData> Deserialize(string data)
        {
            var serializer = new XmlSerializer(typeof(List<AccountAddedEventData>));
            object result;

            using (TextReader reader = new StringReader(data))
            {
                result = serializer.Deserialize(reader);
            }

            return (List<AccountAddedEventData>)result;

        }

    }
}
