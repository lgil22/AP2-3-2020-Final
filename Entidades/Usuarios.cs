﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Entidades
{
    public class Usuarios
    {
        [Key]
        [Required(ErrorMessage = "Es obligatorio introducir el campo 'UsuarioId'")]
        [Range(0, 2000000, ErrorMessage = "El id debe ser mayor o igual a cero.")]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir el campo 'Fecha'")]
       // [FechaValidacion]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir el campo 'Nombres'")]
       // [NombresValidacion]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir el campo 'Nombre Usuario'")]
        public string NombreUsuario { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir el campo 'Clave'")]
        public string Contrasena { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir el campo 'Email'")]
      //  [EmailValidacion]
        public string Email { get; set; }

        public Usuarios()
        {
            UsuarioId = 0;
            Fecha = DateTime.Now;
            Nombres = string.Empty;
            NombreUsuario = string.Empty;
            Contrasena = string.Empty;
            Email = string.Empty;
            
        }
    }
}
