

namespace GRPC.Patient.Repository
{
    public class PatientRepository : IPatientRepository
    {
        private readonly Data.ApplicationDbContext _context;
        public PatientRepository(Data.ApplicationDbContext context)
        {
            _context = context;    
        }

        public void AddPatient(Domain.Patient patient)
        {
             _context.Patients.Add(patient);    
             _context.SaveChanges();
        }

        public ICollection<Domain.Patient> GetAllPatients()
        {
            return _context.Patients.ToList();
        }
    }
}
