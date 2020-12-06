using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Entidades
{
    public class Ventas
    {
        [Key]
        public int VentaId { get; set; }
        public int ClienteId { get; set; }
        public string TipoPago { get; set; }
        public decimal Balance { get; set; }
        public DateTime Fecha { get; set; }

        [ForeignKey("VentaId")]

        public virtual List<VentasDetalles> Detalles { get; set; }

        public Ventas()
        {
            VentaId = 0;
            ClienteId = 0;
            TipoPago = string.Empty;
            Balance = 0;
            Fecha = DateTime.Now;

            Detalles = new List<VentasDetalles>();
        }
    }
}
