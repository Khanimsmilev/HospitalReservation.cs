using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalReservation.Models
{
    public class Doctor
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public int Experience { get; set; }
        public Dictionary<string, bool> AppointmentSlots { get; set; } = new Dictionary<string, bool>
        {
            { "09:00-11:00", false },
            { "12:00-14:00", false },
            { "15:00-17:00", false }
        };
        /*        public Dictionary<string, Dictionary<string, bool>> AppointmentSlots { get; set; } = new Dictionary<string, Dictionary<string, bool>>
                {
                                {"Monday",new Dictionary<string,bool>{
                        { "09:00-11:00", false },
                        { "12:00-14:00", false },
                        { "15:00-17:00", false } } },

                                {"Tuesday",new Dictionary<string,bool>{
                        { "09:00-11:00", false },
                        { "12:00-14:00", false },
                        { "15:00-17:00", false } } },

                                {"Wednesday",new Dictionary<string,bool>{
                        { "09:00-11:00", false },
                        { "12:00-14:00", false },
                        { "15:00-17:00", false } } },

                                {"Thursday",new Dictionary<string,bool>{
                        { "09:00-11:00", false },
                        { "12:00-14:00", false },
                        { "15:00-17:00", false } } },

                                {"Friday",new Dictionary<string,bool>{
                        { "09:00-11:00", false },
                        { "12:00-14:00", false },
                        { "15:00-17:00", false } } },*/


    };
}
