﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Models
{
    [DataContract]
    public class User
    {
        [DataMember]
        public string Name { get; set; }
    }
}
