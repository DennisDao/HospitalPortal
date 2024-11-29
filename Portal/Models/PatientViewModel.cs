using GRPC.Patient;
using System.Runtime.CompilerServices;

namespace Portal.Models
{
    public class PatientViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DateOfBirth { get; set; } 
        public string Gender { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Ward { get; set; }
        public string Bed { get; set; }
        public string Unit { get; set; }
        public string AdmissionDate { get; set; }
        public string DischargedDate { get; set; }
        public string TreatingDoctor { get; set; }
    }

    public static class PatientProto
    {
        public static PatientViewModel ToDto(this Patient patient) 
        {
            return new PatientViewModel
            {
                Id = patient.Id,
                Name = patient.Name,
                DateOfBirth = patient.DateOfBirth,
                Gender = patient.Gender,
                City = patient.City,
                PostalCode = patient.PostalCode,
                Ward = patient.Ward,
                Bed = patient.Bed,
                Unit = patient.Unit,
                AdmissionDate = patient.AdmissionDate,
                DischargedDate = patient.DischargedDate,
                TreatingDoctor = patient.TreatingDoctor,
            };
        }

        public static AddPatientRequest ToPatientRequest(this PatientViewModel patient)
        {
            return new AddPatientRequest
            {
                Name = patient.Name,
                DateOfBirth = patient.DateOfBirth,
                Gender = patient.Gender,
                City = patient.City,
                PostalCode = patient.PostalCode,
                Ward = patient.Ward,
                Bed = patient.Bed,
                Unit = patient.Unit,
                AdmissionDate = patient.AdmissionDate,
                DischargedDate = patient.DischargedDate,
                TreatingDoctor = patient.TreatingDoctor,
            };
        }
    }
}
