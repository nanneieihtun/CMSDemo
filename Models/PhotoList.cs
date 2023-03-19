using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelAdmin.Models
{
    public class PhotoList
    {
        public int ID { get; set; }
        public string PhotoUrl { get; set; }
        public string Type { get; set; }
        public Nullable<DateTime> Accesstime { get; set; }
    }
}
