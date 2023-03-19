using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelAdmin.Models
{
    public class AdminUser
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Nullable<DateTime>  Accesstime { get; set; }
        public Boolean RememberMe { get; set; }
    }
}
