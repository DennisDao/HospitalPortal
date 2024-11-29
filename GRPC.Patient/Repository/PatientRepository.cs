
namespace GRPC.Patient.Repository
{
    public class PatientRepository : IPatientRepository
    {
        private readonly Data.ApplicationDbContext _context;
        public PatientRepository(Data.ApplicationDbContext context)
        {
            _context = context;    
        }

        public ICollection<Domain.Patient> GetAllPatients()
        {
            return _context.Patients.ToList();
        }
    }
}
