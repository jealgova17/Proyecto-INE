using Proyecto_INE.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Proyecto_INE.ViewModels
{
    public class CandidatoViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Nombre del Candidato es obligatorio")]//Obligatorio
        [StringLength(100, ErrorMessage = "La longitud es de 100 caracteres")]//Longitud de la cadena
        public string NombreCandidato { get; set; }

        [Required(ErrorMessage = "El campo Apellido Paterno del Candidato es obligatorio")]//Obligatorio
        [StringLength(100, ErrorMessage = "La longitud es de 100 caracteres")]//Longitud de la cadena
        public string ApellidoPaternoCandidato { get; set; }

        [Required(ErrorMessage = "El campo Apellido Materno del Candidato es obligatorio")]//Obligatorio
        [StringLength(100, ErrorMessage = "La longitud es de 100 caracteres")]
        public string ApellidoMaternoCandidato { get; set; }


        [ForeignKey("PartidoPolitico")]
        [Required(ErrorMessage = "El campo PartidoPoliticoId es obligatorio")]
        [Range(0, int.MaxValue, ErrorMessage = "Debe ser un numero entero")]
        public int PartidoPoliticoId { get; set; }
        public PartidoPolitico PartidoPolitico { get; set; }
    }
}