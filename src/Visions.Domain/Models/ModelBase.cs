namespace Visions.Domain.Models
{
    public class ModelBase
    {
        public long Id { get; set; }
        public DateTime Inclusao { get; set; } = DateTime.UtcNow;

    }
}
