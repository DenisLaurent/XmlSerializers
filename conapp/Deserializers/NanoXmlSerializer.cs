using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data.Sql;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.Xml.XPath;
using TObject.Shared;
using System.Runtime.Serialization;
using System.Globalization;

namespace XmlDeserializersTestApp.Deserializers
{

    public class NanoXmlSerializer : IDeserializer<List<AccountAddedEventData>>
    {
        public List<AccountAddedEventData> Deserialize(string data)
        {

            NanoXMLDocument xml = new NanoXMLDocument(data);
            List<AccountAddedEventData> l = new List<AccountAddedEventData>();

            List<NanoXMLNode> xn = xml.RootNode.SubNodes.ToList();

            for (int i = 0; i < xn.Count(); i++)
            {



                var OBJ = new AccountAddedEventData()
                {

                    dboId = xn[i]["dboId"].Value,
                    id = Convert.ToInt64(xn[i]["id"].Value),
                    number = xn[i]["number"].Value,
                    formattedNumber = xn[i]["formattedNumber"].Value,
                    info = xn[i]["info"].Value,
                    salias = xn[i]["salias"].Value,
                    balance = Convert.ToDecimal(xn[i]["balance"].Value),
                    limit = Convert.ToDecimal(xn[i]["limit"].Value),
                    actual = Convert.ToDateTime(xn[i]["actual"].Value),
                    beginDate = Convert.ToDateTime(xn[i]["beginDate"].Value),
                    endDate = Convert.ToDateTime(xn[i]["endDate"].Value),
                    currency = Convert.ToInt32(xn[i]["currency"].Value),
                    status = xn[i]["status"].Value,
                    bic = xn[i]["bic"].Value,
                    correspondentAccount = xn[i]["correspondentAccount"].Value,
                    name = xn[i]["name"].Value,
                    payee = xn[i]["payee"].Value,
                    clientRef = Convert.ToInt32(xn[i]["clientRef"].Value)


                };
                l.Add(OBJ);
            }
            return l;

        }

        static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }
    }

}
