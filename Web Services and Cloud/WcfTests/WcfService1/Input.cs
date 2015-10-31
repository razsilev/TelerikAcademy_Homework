using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfService1
{
    [DataContract]
    public class Input
    {
        [DataMember]
        public int X { get; set; }
        
        [DataMember]
        public int Y { get; set; }
    }
}