namespace Track2GrowProject.API.DTOs
{
    public class CreateUserDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }  // Plaintext for now
        public string Role { get; set; }      // "TeamLead", "Employee", "Viewer"
        public Guid? ManagerId { get; set; }  // For Employee → TeamLead
    }
}
