namespace GRPC.Patient.Repository
{
    public interface IPatientRepository
    {
        /// <summary> Get all patients </summary>
        ICollection<Domain.Patient> GetAllPatients();

        /// <summary>Create a new patient </summary>
        void AddPatient(Domain.Patient patient);
    }
}
