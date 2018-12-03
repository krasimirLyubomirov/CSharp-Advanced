namespace Hospital
{
    using System;
    using System.Collections.Generic;

    public class Room
    {
        public List<Patient> Patients { get; private set; }
        public int Id { get; private set; }

        public Room(int id)
        {
            Id = id;
            Patients = new List<Patient>();
        }

        public void AddPatient(Patient patient)
        {
            if (Patients.Count >= 3)
            {
                throw new Exception();
            }

            this.Patients.Add(patient);
        }
    }
}
