using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelAdmin.Models
{
    public class Reservation
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phonumber { get; set; }
        public string RoomType { get; set; }
        public int NoOfGuest { get; set; }
        public int NoOfRoom { get; set; }
        public int NoOfNight { get; set; }
        public Nullable<DateTime> Accesstime { get; set; }
        public Nullable<DateTime> CheckInDate { get; set; }
        public Nullable<DateTime> CheckOutDate { get; set; }
        public string Price { get; set; }
    }
}
