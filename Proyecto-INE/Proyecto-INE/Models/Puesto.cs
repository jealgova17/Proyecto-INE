using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proyecto_INE.Models
{
  
        public class Puesto
        {
            [Key]
            public int Id { get; set; }

            [Required(ErrorMessage = "El campo Cargo es obligatorio")]//Obligatorio
            [StringLength(100, ErrorMessage = "La longitud es de 100 caracteres")]//Longitud de la cadena
            public string Cargo { get; set; }

            public virtual ICollection<Candidato> Candidatos { get; set; }
        }
    }
