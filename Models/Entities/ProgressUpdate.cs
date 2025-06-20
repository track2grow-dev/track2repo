namespace Track2GrowProject.API.Models.Entities
{
    public class ProgressUpdate
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid CommitmentId { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }

        // Navigation Properties
        public Commitment Commitment { get; set; }
    }
}
