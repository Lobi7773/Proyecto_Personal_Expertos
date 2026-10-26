using Microsoft.EntityFrameworkCore;
using Proyecto_Expertos.Domain.Entities;

namespace Proyecto_Expertos.Infrastructure.Data
{
    public class PPEDBContext : DbContext
    {
        public PPEDBContext(DbContextOptions<PPEDBContext> options) : base(options)
        {
        }

        public DbSet<PPE_Global> PPE_Global { get; set; }
        public DbSet<Motor> Motores { get; set; } = null!;
        public DbSet<Transmision> Transmisiones { get; set; } = null!;
        public DbSet<SistemaFrenos> SistemasFrenos { get; set; } = null!;
        public DbSet<Suspension> Suspensiones { get; set; } = null!;
    }
}