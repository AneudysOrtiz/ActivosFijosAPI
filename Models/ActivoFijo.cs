using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ActivosFijosAPI.Models
{
    public class ActivoFijo
    {
        [Key]
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int DepartamentoId { get; set; }
        public int TipoActivoId { get; set; }
        public DateTime FechaRegistro { get; set; }
        public decimal ValorCompra { get; set; }
        public decimal DepreciacionAcumulada { get; set; }
        public virtual Departamento Departamento { get; set; }
        public virtual TipoActivo TipoActivo { get; set; }
        public virtual ICollection<CalculoDepreciacion> CalculosDepreciaciones { get; set; }
    }
}
