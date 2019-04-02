using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proyecto_INE.ViewModels
{
    public class CandidatoViewModel
    {
        [Required(ErrorMessage = "El campo Nombre del Candidato es obligatorio")]//Obligatorio
        [StringLength(100, ErrorMessage = "La longitud es de 100 caracteres")]//Longitud de la cadena
        public string NombreCandidato { get; set; }

        [Required(ErrorMessage = "El campo Apellido Paterno del Candidato es obligatorio")]//Obligatorio
        [StringLength(100, ErrorMessage = "La longitud es de 100 caracteres")]//Longitud de la cadena
        public string ApellidoPaternoCandidato { get; set; }

        [Required(ErrorMessage = "El campo Apellido Materno del Candidato es obligatorio")]//Obligatorio
        [StringLength(100, ErrorMessage = "La longitud es de 100 caracteres")]
        public string ApellidoMaternoCandidato { get; set; }
    }
}