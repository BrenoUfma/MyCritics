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
        public MyCriticsContext() {
        }

        public MyCriticsContext (DbContextOptions<MyCriticsContext> options)
            : base(options)
        {
        }

        public DbSet<MyCritics.Models.Usuario> Usuario { get; set; }

        public DbSet<MyCritics.Models.Filme> Filme { get; set; }

        public DbSet<MyCritics.Models.Ator> Ator { get; set; }

        public DbSet<MyCritics.Models.Sonoplastia> Sonoplastia { get; set; }

        public DbSet<MyCritics.Models.Diretor> Diretor { get; set; }

        public DbSet<MyCritics.Models.Roteiro> Roteiro { get; set; }

        public DbSet<MyCritics.Models.Figurino> Figurino { get; set; }


    }
}
