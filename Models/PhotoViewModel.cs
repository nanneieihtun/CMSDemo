using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelAdmin.Models
{
    public class PhotoViewModel
    {
        public int ID { get; set; }
        public List<IFormFile> Photos { get; set; }
        public string Type { get; set; }
        public Nullable<DateTime> Accesstime { get; set; }
    }
}
