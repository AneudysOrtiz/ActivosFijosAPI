using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ActivosFijosAPI.Models
{
    public class CalculoDepreciacion
    {
        public int Id { get; set; }
        public int AnoPreceso { get; set; }
        public int MesPreceso { get; set; }
        public int ActivoFijoId { get; set; }
        public DateTime FechaProceso { get; set; }
        public decimal MontoDepreciado { get; set; }
        public decimal DepreciacionAcumulada { get; set; }
        public string CuentaCompra { get; set; }
        public string CuentaDepreciacion { get; set; }
        public virtual ActivoFijo ActivoFijo { get; set; }
    }
}
