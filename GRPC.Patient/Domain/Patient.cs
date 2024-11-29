namespace GRPC.Patient.Domain
{
    public class Patient
    {
        public int PatientId { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Ward { get; set; }
        public string Bed { get; set; }
        public string Unit { get; set; }
        public DateTime AdmissionDate { get; set; }
        public DateTime? DischargedDate { get; set; }
        public string TreatingDoctor { get; set; }

        public GRPC.Patient.Patient ToProto()
        {
            return new GRPC.Patient.Patient
            {
                Id = PatientId,
                Name = Name,
                DateOfBirth = DateOfBirth.ToString("yyyy-MM-dd"),
                Gender = Gender,
                City = City,
                PostalCode = PostalCode,
                Ward = Ward,
                Bed = Bed,
                Unit = Unit,
                AdmissionDate = AdmissionDate.ToString("yyyy-MM-dd"),
                DischargedDate = DischargedDate?.ToString("yyyy-MM-dd"),
                TreatingDoctor = TreatingDoctor
            };
        }
    }
}
