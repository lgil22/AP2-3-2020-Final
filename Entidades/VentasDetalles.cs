using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Entidades
{
    public class VentasDetalles
    {
        [Key]
        public int VentaId { get; set; }
        public int ArticuloId { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }

        public VentasDetalles()
        {
            VentaId = 0;
            ArticuloId = 0;
            Cantidad = 0;
            Precio = 0;
        }
    }
}
