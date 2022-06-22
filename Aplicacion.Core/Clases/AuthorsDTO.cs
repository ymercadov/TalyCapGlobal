using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Aplicacion.Core
{
    public class AuthorsDTO
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
