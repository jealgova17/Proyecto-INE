using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Proyecto_INE.Models
{
    public class Municipio
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Municipio es obligatorio")]//Obligatorio
        [StringLength(100, ErrorMessage = "La longitud es de 100 caracteres")]//Longitud de la cadena
        public string Nombre { get; set; }

        [ForeignKey("Estado")]
        [Required(ErrorMessage = "El campo EstadoId es obligatorio")]
        [Range(0, int.MaxValue, ErrorMessage = "Debe ser un numero entero")]
        public int EstadoId { get; set; }
        public Estado Estado { get; set; }


        public virtual ICollection<Candidato> Candidatos { get; set; }
        public virtual ICollection<Persona> Personas { get; set; }


    }
}