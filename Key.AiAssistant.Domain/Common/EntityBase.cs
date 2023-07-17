namespace Key.AiAssistant.Domain.Common
{
    public abstract class EntityBase
    {
        public int Id { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTimeOffset UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}
