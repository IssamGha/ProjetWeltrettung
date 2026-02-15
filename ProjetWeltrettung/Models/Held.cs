using System.ComponentModel.DataAnnotations;

namespace ProjetWeltrettung.Models
{
    public class Held
    {
        public int HeldId { get; set; }
        [Required]
        public string Vorname { get; set; }
        [Required]
        public string Nachname { get; set; }
        public string Beruf { get; set; }
        public ICollection<Bedrohung>? Bedrohungen { get; set; }
    }
}
