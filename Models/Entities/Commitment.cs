namespace Track2Grow.API.Models.Entities
{
    public class Commitment
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid GoalId { get; set; }
        public Guid AssignedBy { get; set; } // TeamLead
        public Guid AssignedTo { get; set; } // Employee
        public string TargetDescription { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation Properties
        public CompanyGoal Goal { get; set; }
        public User AssignedByUser { get; set; }
        public User AssignedToUser { get; set; }
        public ICollection<ProgressUpdate> ProgressUpdates { get; set; }
    }
}
