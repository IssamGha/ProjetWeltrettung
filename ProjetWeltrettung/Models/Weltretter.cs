using System.ComponentModel.DataAnnotations;

namespace ProjetWeltrettung.Models
{
    public class Weltretter
    {
        public int Id { get; set; }
        [Required]
        public string Vorname { get; set; }
        [Required]
        public string Nachname { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string? Faehigkeit { get; set; }
        public bool IstVolljaehrig { get; set; }
    }
}
