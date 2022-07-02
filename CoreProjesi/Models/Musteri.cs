using System.ComponentModel.DataAnnotations;

namespace CoreProjesi.Models
{
    public class Musteri
    {
        [Key]

        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string AdSoyad { get; set; } = "";


        [StringLength(10)]
        public string Cinsiyet { get; set; } = "";

        [Required]
        [StringLength(30)]
        public string Tur { get; set; } = "";



    }
}
