
using System.ComponentModel.DataAnnotations;

namespace Dominio.Core
{
    public class Books
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage = "Este campo es requerido.")]//Obligatorio       
        public string title { get; set; }
        [Required(ErrorMessage = "Este campo es requerido.")]//Obligatorio       
        public string description { get; set; }
        public int pageCount { get; set; }
        [Required(ErrorMessage = "Este campo es requerido.")]//Obligatorio       
        public string excerpt { get; set; }
        public string publishDate { get; set; }
    }
}
