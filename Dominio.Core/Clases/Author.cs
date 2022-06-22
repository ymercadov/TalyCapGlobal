
using System.ComponentModel.DataAnnotations;
namespace Dominio.Core
{
    public class Author
    {
        [Key]
        public int id { get; set; }
        public int idBook { get; set; }
        [Required(ErrorMessage = "Este campo es requerido.")]//Obligatorio       
        public string firstName { get; set; }
        [Required(ErrorMessage = "Este campo es requerido.")]//Obligatorio   
        public string lastName { get; set; }
    }
}
