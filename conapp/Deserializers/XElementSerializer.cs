using System.Collections.Generic;
using System.Xml.Serialization;
using System.Xml.Linq;

namespace XmlDeserializersTestApp.Deserializers
{

    public class XElementSerializer : IDeserializer<List<AccountAddedEventData>>
    {
        public List<AccountAddedEventData> Deserialize(string data)
        {
            var xElement = XElement.Parse(data);

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<AccountAddedEventData>));

            return (List<AccountAddedEventData>)xmlSerializer.Deserialize(xElement.CreateReader());
        }

    }
}
