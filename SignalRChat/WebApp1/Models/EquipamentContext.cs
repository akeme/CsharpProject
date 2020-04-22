using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp1.Models
{
    public class EquipamentContext : DbContext
    {
        public EquipamentContext(DbContextOptions<EquipamentContext> options)
            : base(options)
        {
        }

        public DbSet<Equipament> Equipaments { get; set; }
    }
}

