namespace GRPC.Patient.Repository
{
    public interface IPatientRepository
    {
        /// <summary> Get all customers </summary>
        ICollection<Domain.Patient> GetAllPatients();
    }
}
