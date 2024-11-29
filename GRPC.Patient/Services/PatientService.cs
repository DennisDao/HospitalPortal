using Azure;
using Grpc.Core;
using GRPC.Patient;
using GRPC.Patient.Repository;
using System.Reflection;

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

        public override Task<Patient> AddPatient(AddPatientRequest request, ServerCallContext context)
        {
            try
            {
                var patient = new Domain.Patient()
                {
                    Name = request.Name,
                    DateOfBirth = DateTime.Parse(request.DateOfBirth),
                    Gender = request.Gender,
                    City = request.City,
                    PostalCode = request.PostalCode,
                    Ward = request.Ward,
                    Bed = request.Bed,
                    Unit = request.Unit,
                    AdmissionDate = DateTime.Parse(request.AdmissionDate),
                    DischargedDate = DateTime.Parse(request.DischargedDate),
                    TreatingDoctor = request.TreatingDoctor
                };

                _patientRepository.AddPatient(patient);

                var patientResponse = patient.ToProto();

                return Task.FromResult(patientResponse);
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}
