using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Proyecto_INE.Models
{
    public class Persona
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Nombre es obligatorio")]//Obligatorio
        [StringLength(100, ErrorMessage = "La longitud es de 100 caracteres")]//Longitud de la cadena
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo ApellidoPaterno es obligatorio")]//Obligatorio
        [StringLength(100, ErrorMessage = "La longitud es de 100 caracteres")]//Longitud de la cadena
        public string ApellidoPaterno { get; set; }

        [Required(ErrorMessage = "El campo ApellidoMaterno es obligatorio")]//Obligatorio
        [StringLength(100, ErrorMessage = "La longitud es de 100 caracteres")]//Longitud de la cadena
        public string ApellidoMaterno { get; set; }

        [ForeignKey("Pais")]
        [Required(ErrorMessage = "El campo Pais del Mundo es obligatorio")]
        [Range(0, int.MaxValue, ErrorMessage = "Debe ser un numero entero")]
        public int PaisId { get; set; }
        public Pais Pais { get; set; }


        [ForeignKey("Estado")]
        [Required(ErrorMessage = "El campo MunicipiosId es obligatorio")]
        [Range(0, int.MaxValue, ErrorMessage = "Debe ser un numero entero")]
        public int EstadoId { get; set; }
        public Estado Estado { get; set; }



        [ForeignKey("Municipio")]
        [Required(ErrorMessage = "El campo MunicipiosId es obligatorio")]
        [Range(0, int.MaxValue, ErrorMessage = "Debe ser un numero entero")]
        public int MunicipioId { get; set; }
        public Municipio Municipio { get; set; }

        [Required(ErrorMessage = "El campo Colonia es obligatorio")]//Obligatorio
        [StringLength(100, ErrorMessage = "La longitud es de 100 caracteres")]//Longitud de la cadena
        public string Colonia { get; set; }

        [Required(ErrorMessage = "El campo Calle es obligatorio")]//Obligatorio
        [StringLength(100, ErrorMessage = "La longitud es de 100 caracteres")]//Longitud de la cadena
        public string Calle { get; set; }

        [Required(ErrorMessage = "El campo Numero Exterior es obligatorio")]//Obligatorio
        [StringLength(100, ErrorMessage = "La longitud es de 100 caracteres")]//Longitud de la cadena
        public string NumeroExterior { get; set; }


        [StringLength(100, ErrorMessage = "La longitud es de 100 caracteres")]//Longitud de la cadena
        public string NumeroInterior { get; set; }

        [Required(ErrorMessage = "El campo Codigo Postal es obligatorio")]//Obligatorio
        [Range(0, int.MaxValue, ErrorMessage = "Debe ser un numero entero")]
        public int CodigoPostal { get; set; }

        [Required(ErrorMessage = "El campo Clave del Elector es obligatorio")]//Obligatorio
        [StringLength(100, ErrorMessage = "La longitud es de 100 caracteres")]//Longitud de la cadena
        public string ClaveElector { get; set; }

        [Required(ErrorMessage = "El campo Curp es obligatorio")]//Obligatorio
        [StringLength(100, ErrorMessage = "La longitud es de 100 caracteres")]//Longitud de la cadena
        public string Curp { get; set; }

        [Required(ErrorMessage = "El campo Año de Registro es obligatorio")]//Obligatorio
        [Range(0, int.MaxValue, ErrorMessage = "Debe ser un numero entero")]
        public int AñoRegistro { get; set; }

        [Required(ErrorMessage = "El campo Emision es obligatorio")]//Obligatorio
        [Range(0, int.MaxValue, ErrorMessage = "Debe ser un numero entero")]
        public int Emision { get; set; }

        [Required(ErrorMessage = "El campo Vigencia es obligatorio")]//Obligatorio
        [Range(0, int.MaxValue, ErrorMessage = "Debe ser un numero entero")]
        public int Vigencia { get; set; }

        public String FechaNacimiento { get; set; }

        [Required(ErrorMessage = "El campo Sexo es obligatorio")]//Obligatorio
        [StringLength(100, ErrorMessage = "La longitud es de 100 caracteres")]//Longitud de la cadena
        public string Sexo { get; set; }

        [Required(ErrorMessage = "El campo CIC es obligatorio")]//Obligatorio
        [StringLength(100, ErrorMessage = "La longitud es de 100 caracteres")]//Longitud de la cadena
        public string CIC { get; set; }

        [DefaultValue("false")]
        public int voto { get; set; }
      

    }
}