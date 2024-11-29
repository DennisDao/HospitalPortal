using Microsoft.EntityFrameworkCore;

namespace GRPC.Patient.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Domain.Patient> Patients { get; set; }
    }

}
