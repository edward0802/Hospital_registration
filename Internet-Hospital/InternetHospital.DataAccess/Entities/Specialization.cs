﻿using System;
using System.Collections.Generic;
using System.Text;

namespace InternetHospital.DataAccess.Entities
{
    public class Specialization
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Doctor> Doctors { get; set; }
    }
}
