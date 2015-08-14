using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;

namespace XmlDeserializersTestApp.Deserializers
{

    public class DataContractXmlSerializer : IDeserializer<List<AccountAddedEventData>>
    {

        public List<AccountAddedEventData> Deserialize(string data)
        {
            DataContractSerializer ds = new DataContractSerializer(typeof(List<AccountAddedEventData>));
            var xr = XmlReader.Create(new StringReader(data));


            var obj = ds.ReadObject(xr);

            return (List<AccountAddedEventData>)obj;
        }
    }
}
