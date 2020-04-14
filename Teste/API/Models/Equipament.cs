using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Equipament
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int ReadingValue { get; set; }
        public byte Status { get; set; }


    }
}
