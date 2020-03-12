using ActivosFijosAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ActivosFijosAPI
{
    public class ActivosFijosDb : DbContext
    {
        public ActivosFijosDb(DbContextOptions<ActivosFijosDb> options) : base(options)
        {

        }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<TipoActivo> TiposActivos { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<ActivoFijo> ActivosFijos { get; set; }
        public DbSet<CalculoDepreciacion> CalculosDepreciaciones { get; set; }
        
    }
}
