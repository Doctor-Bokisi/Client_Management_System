using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace clientLibrary
{
    [DataContract]
    public class clientC
    {
        [DataMember]
        public int UserId { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string gender { get; set; }
        [DataMember]
        public string ResidentialAdd { get; set; }
        [DataMember]
        public string WorkAdd { get; set; }
        [DataMember]
        public string PostalAdd { get; set; }
        [DataMember]
        public string mobileNumber { get; set; }
        [DataMember]
        public string workNumber { get; set; }
    }
}
