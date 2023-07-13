namespace StudentAdminPortal.API.DomainModels
{
    public class UpdateStudentRequest
    {
        public String? FirstName { get; set; }
        public String? LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public String? Email { get; set; }
        public long Mobile { get; set; }
        public Guid GenderId { get; set; }
        public string? PhysicalAddress { get; set; }
        public string? PostalAddress { get; set; }

    }
}
