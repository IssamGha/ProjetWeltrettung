using System.ComponentModel.DataAnnotations;

namespace ProjetWeltrettung.Models
{
    public class Aggressor
    {
        public int AggressorId { get; set; }
        [Required]
        public string Vorname { get; set; }
        [Required]
        public string Nachname { get; set; }
        public string Spezialgebiet { get; set; }
        public ICollection<Bedrohung>? Bedrohungen { get; set; }
    }
}
