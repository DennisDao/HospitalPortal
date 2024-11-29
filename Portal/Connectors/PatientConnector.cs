using Grpc.Net.Client;
using GRPC.Patient;
using Portal.Models;

namespace Portal.Connectors
{
    public class PatientConnector
    {
        private readonly string _grpcServerAddress = "http://localhost:5035";

        public PatientConnector()
        {
   
        }

        public async Task<List<PatientViewModel>> ListPatientsAsync()
        {
            using var channel = GrpcChannel.ForAddress(_grpcServerAddress);
            var client = new PatientService.PatientServiceClient(channel);
            var response = await client.ListPatientsAsync(new Empty());

            var result = new List<PatientViewModel>();

            foreach (var p in response.Patients)
            {
                result.Add(p.ToDto());
            }

            await channel.ShutdownAsync(); // Close the TCP connection

            return result;
        }

        public async Task<Patient> AddPatient(PatientViewModel patient)
        {
            using var channel = GrpcChannel.ForAddress(_grpcServerAddress);
            var client = new PatientService.PatientServiceClient(channel);
            var request = patient.ToPatientRequest();
            var response = await client.AddPatientAsync(request);
            await channel.ShutdownAsync(); // Close the TCP connection

            return response;
        }
    }
}
