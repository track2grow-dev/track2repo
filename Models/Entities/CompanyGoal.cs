namespace Track2Grow.API.Models.Entities
{
    public class CompanyGoal
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; } // Planned, InProgress, Completed
        public Guid CreatedBy { get; set; }

        // Navigation Properties
        public User Creator { get; set; }
        public ICollection<Commitment> Commitments { get; set; }
    }
}
