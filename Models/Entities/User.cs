namespace Track2Grow.API.Models.Entities
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; } // Admin, TeamLead, Employee, Viewer
        public Guid? ManagerId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation Properties
        public ICollection<Commitment> AssignedCommitments { get; set; }
        public ICollection<Commitment> CreatedCommitments { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
