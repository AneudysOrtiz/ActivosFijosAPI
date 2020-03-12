using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ActivosFijosAPI.Models
{
    public class Empleado
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public int DepartamentoId { get; set; }
        public int TipoPersona { get; set; }
        public DateTime FechaIngreso { get; set; }
        public bool Estado { get; set; }
        public virtual Departamento Departamento { get; set; }
    }
}
