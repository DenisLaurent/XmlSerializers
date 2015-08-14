using System;
using System.Runtime.Serialization;

namespace XmlDeserializersTestApp
{

    [DataContract(Namespace = "")]
    public class AccountAddedEventData
    {
        [DataMember]
        public string dboId { get; set; }
        [DataMember]
        public long id { get; set; }
        [DataMember]
        public string number { get; set; }
        [DataMember]
        public string formattedNumber { get; set; } 
        [DataMember]
        public string info { get; set; }
        [DataMember]
        public string salias { get; set; } 
        [DataMember]
        public decimal balance { get; set; } 
        [DataMember]
        public decimal limit { get; set; } 
        [DataMember]
        public DateTime actual { get; set; }
        [DataMember]
        public DateTime beginDate { get; set; } 
        [DataMember]
        public DateTime endDate { get; set; }
        [DataMember]
        public int currency { get; set; } 
        [DataMember]
        public string status { get; set; } 
        [DataMember]
        public string bic { get; set; } 
        [DataMember]
        public string correspondentAccount { get; set; } 
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string payee { get; set; } 
        [DataMember]
        public long clientRef { get; set; }

    }
}
