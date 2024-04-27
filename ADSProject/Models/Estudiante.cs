﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ADSProject.Models
{
    [PrimaryKey(nameof(IdEstudiante))]
    public class Estudiante
    {

        public int IdEstudiante { get; set; }

        [Required(ErrorMessage = "Este es un campo requerido")]
        [MaxLength(length: 50, ErrorMessage = "La longitud del campo no puede ser mayor a 50 caracteres.")]

        public string NombresEstudiante { get; set; }

        [Required(ErrorMessage = "Este es un campo requerido")]
        [MaxLength(length: 50, ErrorMessage = "La longitud del campo no puede ser mayor a 50 caracteres.")]

        public string ApellidosEstudiante { get; set; }

        [Required(ErrorMessage = "Este es un campo requerido")]
        [MinLength(length: 3, ErrorMessage = "La longitud del campo no puede ser menor a 3 caracteres.")]
        [MaxLength(length: 12, ErrorMessage = "La longitud del campo no puede ser mayor a 12 caracteres.")]


        public string CodigoEstudiante { get; set; }

        [Required(ErrorMessage = "Este es un campo requerido")]
        [MaxLength(length: 254, ErrorMessage = "La longitud del campo no puede ser mayor a 254 caracteres.")]
        [EmailAddress(ErrorMessage = "El formato del correo electronico no es correcto.")]
        public string CorreoEstudiante { get; set; }
    }
}