using Grpc.Core;
using GRPC.Patient;
using GRPC.Patient.Repository;

namespace GRPC.Patient.Services
{
    public sealed class PatientService : GRPC.Patient.PatientService.PatientServiceBase
    {
        private readonly IPatientRepository _patientRepository;
        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public override Task<ListPatientsResponse> ListPatients(Empty request, ServerCallContext context)
        {
            var domainPatients = _patientRepository.GetAllPatients();
            var patientsResponse = new List<Patient>();

            foreach (var domainPatient in domainPatients)
            {
                patientsResponse.Add(domainPatient.ToProto());
            }

            var response = new ListPatientsResponse
            {
                Patients = { patientsResponse } 
            };

            return Task.FromResult(response);
        }
    }
}
