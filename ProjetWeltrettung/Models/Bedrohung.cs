using System.ComponentModel.DataAnnotations;

namespace ProjetWeltrettung.Models
{
    public class Bedrohung
    {
        public int BedrohungId { get; set; }
        [Required]
        public string Bedrohungsname { get; set; }

        public bool Existiert { get; set; } = true;
        // Fremdschlüssel
        public int AggressorId { get; set; }
        public Aggressor? Aggressor { get; set; }
        public int? HeldId { get; set; }
        public Held? Held { get; set; }
    }
}
