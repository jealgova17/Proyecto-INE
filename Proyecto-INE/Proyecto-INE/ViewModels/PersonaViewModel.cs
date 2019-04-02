using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proyecto_INE.ViewModels
{
    public class PersonaViewModel
    {

        [Required(ErrorMessage = "El campo Curp es obligatorio")]//Obligatorio
        [StringLength(100, ErrorMessage = "La longitud es de 100 caracteres")]//Longitud de la cadena
        public string Curp { get; set; }

        [Required(ErrorMessage = "El campo CIC es obligatorio")]//Obligatorio
        [StringLength(100, ErrorMessage = "La longitud es de 100 caracteres")]//Longitud de la cadena
        public string CIC { get; set; }
    }
}