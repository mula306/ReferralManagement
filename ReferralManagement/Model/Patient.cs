﻿namespace ReferralManagement.Model
{
    //public class PatientResponse
    //{
    //    public List<Patient> Patients { get; set; }
    //}
    public class Patient
    {
        public int PatientId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Address { get; set; }

        public string Gender { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public DateTime RegistrationDate { get; set; }

    }
}
