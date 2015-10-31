using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace ClassLibrary1.Models
{
    [DataContract]
    public class Message
    {
        [DataMember]
        public string Text { get; set; }

        [DataMember]
        public User User { get; set; }

        [DataMember]
        public DateTime PostDate { get; set; }
    }
}
