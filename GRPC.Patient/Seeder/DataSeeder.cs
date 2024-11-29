using GRPC.Patient.Data;
using System;

namespace GRPC.Patient.Seeder
{
    public static class DataSeeder
    {
        public static WebApplication Seed(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                using var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                try
                {
                    context.Database.EnsureCreated();

                    if (context.Patients.Any() == false)
                    {
                        context.Add(new Domain.Patient
                        {
                            PatientId = 1,
                            Name = "Dennis",
                            DateOfBirth = new DateTime(1995, 7, 29),
                            Gender = "Male",
                            City = "Melbourne",
                            PostalCode = "3000",
                            Ward = "A1",
                            Bed = "101",
                            Unit = "Cardiology",
                            AdmissionDate = DateTime.Now,
                            DischargedDate = DateTime.Now,
                            TreatingDoctor = "Dr. Smith"
                        });

                        context.Add(new Domain.Patient
                        {
                            PatientId = 2,
                            Name = "Tim",
                            DateOfBirth = new DateTime(1991,7,29),
                            Gender = "Male",
                            City = "Melbourne",
                            PostalCode = "3000",
                            Ward = "A2",
                            Bed = "102",
                            Unit = "Cardiology",
                            AdmissionDate = DateTime.Now,
                            DischargedDate = DateTime.Now,
                            TreatingDoctor = "Dr. Trang"
                        });

                        context.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return app;
        }
    }
}
