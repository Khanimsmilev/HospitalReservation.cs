﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalReservation.Models
{
    public class Department
    {
        public string? Name { get; set; }
        public List<Doctor>? Doctors { get; set; }
    }
}
