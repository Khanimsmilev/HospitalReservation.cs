using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalReservation.Models
{
    public class Reservation
    {
        public User? User { get; set; }
        public string? Department { get; set; }
        public string? Doctor { get; set; }
        public string? TimeSlot { get; set; }
    }
}
