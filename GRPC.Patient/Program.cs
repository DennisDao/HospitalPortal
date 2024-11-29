using GRPC.Patient.Data;
using GRPC.Patient.Repository;
using GRPC.Patient.Seeder;
using GRPC.Patient.Services;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("ApplicationConnectionString");
var isUseInMemory = true;
// Add services to the container.
builder.Services.AddGrpc();

if (isUseInMemory)
{
    builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("TPFSports"));
}
else
{
    builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
}

// Register services 
builder.Services.AddScoped<IPatientRepository, PatientRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.MapGrpcService<PatientService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Seed();

app.Run();
