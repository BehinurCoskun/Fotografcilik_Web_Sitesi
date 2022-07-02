using System.ComponentModel.DataAnnotations;

namespace CoreProjesi.Models
{
    public class Mekan
    {
        [Key]
        public int Id { get; set; }
        [Required]

        [StringLength(30)]
        public string Mekanadi { get; set; } = "";

        [Required]

        [StringLength(30)]
        public string il { get; set; } = "";

        [Required]

        [StringLength(30)]
        public string ilce { get; set; } = "";


    }
}
