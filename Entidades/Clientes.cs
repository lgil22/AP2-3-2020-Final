using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Entidades
{
    public class Clientes
    {

        [Key]
        public int ClienteId { get; set; }
        public string Nombres { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string Cedula { get; set; }
        public string Email { get; set; }
        public DateTime FechaNacimiento { get; set; }

        public decimal Balance { get; set; }

        public Clientes()
        {
            ClienteId = 0;
            Nombres = string.Empty;
            Direccion = string.Empty;
            Telefono = string.Empty;
            Celular = string.Empty;
            Email = string.Empty;
            FechaNacimiento = DateTime.Now;
            Balance = 0;
        }
    }
}
