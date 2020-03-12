using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ActivosFijosAPI.Models
{
    public class TipoActivo
    {
        [Key]
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string CuentaContableCompra { get; set; }
        public string CuentaContableDepreciacion { get; set; }
        public bool Estado { get; set; }
        public virtual ICollection<ActivoFijo> ActivosFijos { get; set; }
    }
}
