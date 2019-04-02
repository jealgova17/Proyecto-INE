using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Proyecto_INE.Models

{
    public class Candidato
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("PartidoPolitico")]
        [Required(ErrorMessage = "El campo PartidoPoliticoId es obligatorio")]
        [Range(0, int.MaxValue, ErrorMessage = "Debe ser un numero entero")]
        public int PartidoPoliticoId { get; set; }
        public PartidoPolitico PartidoPolitico { get; set; }


        [ForeignKey("Puesto")]
        [Required(ErrorMessage = "El campo PartidoPoliticoId es obligatorio")]
        [Range(0, int.MaxValue, ErrorMessage = "Debe ser un numero entero")]
        public int PuestoId { get; set; }
        public Puesto Puesto { get; set; }



        [Required(ErrorMessage = "El campo Nombre del Candidato es obligatorio")]//Obligatorio
        [StringLength(100, ErrorMessage = "La longitud es de 100 caracteres")]//Longitud de la cadena
        public string NombreCandidato { get; set; }

        [Required(ErrorMessage = "El campo Apellido Paterno del Candidato es obligatorio")]//Obligatorio
        [StringLength(100, ErrorMessage = "La longitud es de 100 caracteres")]//Longitud de la cadena
        public string ApellidoPaternoCandidato { get; set; }

        [Required(ErrorMessage = "El campo Apellido Materno del Candidato es obligatorio")]//Obligatorio
        [StringLength(100, ErrorMessage = "La longitud es de 100 caracteres")]
        public string ApellidoMaternoCandidato { get; set; }


        [DataType(DataType.DateTime)]
        public DateTime FechaNacimientoCandidato { get; set; }


        [ForeignKey("Municipio")]
        [Required(ErrorMessage = "El campo MunicipioId es obligatorio")]
        [Range(0, int.MaxValue, ErrorMessage = "Debe ser un numero entero")]
        public int MunicipioId { get; set; }
        public Municipio Municipio { get; set; }


        [ForeignKey("Pais")]
        [Required(ErrorMessage = "El campo PaisId es obligatorio")]
        [Range(0, int.MaxValue, ErrorMessage = "Debe ser un numero entero")]
        public int PaisId { get; set; }
        public Pais Pais { get; set; }


        [ForeignKey("Estado")]
        [Required(ErrorMessage = "El campo EstadoId es obligatorio")]
        [Range(0, int.MaxValue, ErrorMessage = "Debe ser un numero entero")]
        public int EstadoId { get; set; }
        public Estado Estado { get; set; }

        public virtual ICollection<Voto> Votos { get; set; }


    }
}