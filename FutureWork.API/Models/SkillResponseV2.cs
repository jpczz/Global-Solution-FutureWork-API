namespace FutureWork.API.Models
{
    public class SkillResponseV2
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Category { get; set; } = null!;

        public string? Description { get; set; }

        public bool IsFutureCritical { get; set; }

        // Campo novo só na V2 - melhora sem quebrar o contrato da V1
        public string ImportanceLevel => IsFutureCritical ? "Alta" : "Normal";
    }
}
