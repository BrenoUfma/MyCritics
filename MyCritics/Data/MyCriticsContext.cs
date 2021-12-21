using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyCritics.Models;

namespace MyCritics.Data
{
    public class MyCriticsContext : DbContext
    {
        public MyCriticsContext (DbContextOptions<MyCriticsContext> options)
            : base(options)
        {
        }

        public DbSet<MyCritics.Models.Usuario> Usuario { get; set; }
    }
}
