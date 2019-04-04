using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Proyecto_INE.Models
{
    public class Voto
    {
        [Key]
        public int Id { get; set; }


        [ForeignKey("Candidato")]
        [Required(ErrorMessage = "El campo CandidatoId es obligatorio")]
        [Range(0, int.MaxValue, ErrorMessage = "Debe ser un numero entero")]
        public int CandidatoId { get; set; }
        public Candidato Candidato { get; set; }

        [Required(ErrorMessage = "El campo votos es obligatorio")]
        [Range(0, int.MaxValue, ErrorMessage = "Debe ser un numero entero")]
        public int votos { get; set; }
    }
}