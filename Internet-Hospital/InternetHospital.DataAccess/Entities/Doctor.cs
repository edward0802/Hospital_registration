using System;
using System.Collections.Generic;
using System.Text;

namespace InternetHospital.DataAccess.Entities
{
    public class Doctor
    {
        public string Id { get; set; }
        //public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public string LicenseURL { get; set; }
        public string DoctorsInfo { get; set; }
        public bool IsApproved { get; set; }

        //public int SpecializationId { get; set; }
        //public Specialization Specialization { get; set; }

        //public int WorkingAddressId { get; set; }
        public Address Address { get; set; }

        public ICollection<Diploma> Diplomas { get; set; }
    }
}
