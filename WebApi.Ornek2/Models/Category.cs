using System.ComponentModel.DataAnnotations;

namespace WebApi.Ornek2.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Ad alanı zorunludur")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Açıklama alanı zorunludur")]
        public string Desc { get; set; }
    }
}
