using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class Book
    {
       
        [DataMember(EmitDefaultValue = false)]
        public string Title { get; set; }
        [DataMember]
        public int  stock { get; set; }
     }
}
