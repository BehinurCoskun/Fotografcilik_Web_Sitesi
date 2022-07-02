using System;
using System.ComponentModel.DataAnnotations;

namespace CoreProjesi.Models
{
    public class Fotografci
    {

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string AdSoyad { get; set; } = "";

        [Required]
        [StringLength(10)]
        public string Cinsiyet { get; set; } = "";


        [Required]
        [Range(8000, 20000, ErrorMessage = "verilen maaş uygun degil")]
        public int Maas { get; set; }
    }
}
