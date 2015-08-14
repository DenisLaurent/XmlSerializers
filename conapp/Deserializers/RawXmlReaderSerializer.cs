using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;


namespace XmlDeserializersTestApp.Deserializers
{

    public class RawXmlReaderSerializer : IDeserializer<List<AccountAddedEventData>>
    {

        public List<AccountAddedEventData> Deserialize(string data)
        {

            XmlReader reader = XmlReader.Create(new StringReader(data));

            List<AccountAddedEventData> elements = new List<AccountAddedEventData>();

            AccountAddedEventData lastElement = null;

            while (reader.Read())
            {
                var nodeName = reader.Name;

                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:

                        switch (nodeName)
                        {
                            case "AccountAddedEventData":
                                lastElement = new AccountAddedEventData();

                                elements.Add(lastElement);
                                break;

                            case "dboId": lastElement.dboId = reader.ReadElementContentAsString(); break;
                            case "id": lastElement.id = reader.ReadElementContentAsLong(); break;
                            case "number": lastElement.number = reader.ReadElementContentAsString(); break;
                            case "formattedNumber": lastElement.formattedNumber = reader.ReadElementContentAsString(); break;
                            case "info": lastElement.info = reader.ReadElementContentAsString(); break;
                            case "salias": lastElement.salias = reader.ReadElementContentAsString(); break;
                            case "balance": lastElement.balance = reader.ReadElementContentAsDecimal(); break;
                            case "limit": lastElement.limit = reader.ReadElementContentAsDecimal(); break;
                            case "actual": lastElement.actual = reader.ReadElementContentAsDateTime(); break;
                            case "beginDate": lastElement.beginDate = reader.ReadElementContentAsDateTime(); break;
                            case "endDate": lastElement.endDate = reader.ReadElementContentAsDateTime(); break;
                            case "currency": lastElement.currency = reader.ReadElementContentAsInt(); break;
                            case "status": lastElement.status = reader.ReadElementContentAsString(); break;
                            case "bic": lastElement.bic = reader.ReadElementContentAsString(); break;
                            case "correspondentAccount": lastElement.correspondentAccount = reader.ReadElementContentAsString(); break;
                            case "name": lastElement.name = reader.ReadElementContentAsString(); break;
                            case "payee": lastElement.payee = reader.ReadElementContentAsString(); break;
                            case "clientRef": lastElement.clientRef = reader.ReadElementContentAsLong(); break;
                        }

                        break;
                }
            }

            return elements;

        }


    }


}
