using Grpc.Core;
using GRPC.Patient;

namespace GRPC.Patient.Services
{
    public sealed class PatientService : GRPC.Patient.PatientService.PatientServiceBase
    {
        public override Task<ListPatientsResponse> ListPatients(Empty request, ServerCallContext context)
        {
            var patients = new List<Patient>
            {
                new Patient
                {
                    Id = 1,
                    Name = "Dennis",
                    DateOfBirth = "1990-01-01",
                    Gender = "Male",
                    City = "Melbourne",
                    PostalCode = "3000",
                    Ward = "A1",
                    Bed = "101",
                    Unit = "Cardiology",
                    AdmissionDate = "2023-01-01",
                    DischargedDate = "2023-01-10",
                    TreatingDoctor = "Dr. Smith"
                }
            };

            var response = new ListPatientsResponse
            {
                Patients = { patients } 
            };

            return Task.FromResult(response);
        }
    }
}
