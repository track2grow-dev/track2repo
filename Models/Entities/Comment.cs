namespace Track2GrowProject.API.Models.Entities
{
    public class Comment
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid RelatedEntityId { get; set; } // Goal or Commitment
        public string EntityType { get; set; } // "Goal" or "Commitment"
        public string Text { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation Property
        public User CreatedByUser { get; set; }
    }
}
