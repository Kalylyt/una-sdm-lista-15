using Microsoft.EntityFrameworkCore;
using GreenDriveApiSeuRa.Models;

namespace GreenDriveApiSeuRa.Data
{
    public class GreenDriveContext : DbContext
    {
        public GreenDriveContext(DbContextOptions<GreenDriveContext> options)
            : base(options)
        {
        }

        public DbSet<Bateria> Baterias { get; set; }
        public DbSet<EstacaoCarga> EstacoesCarga { get; set; }
        public DbSet<RegistroTelemetria> RegistrosTelemetria { get; set; }
        public DbSet<OrdemReciclagem> OrdensReciclagem { get; set; }
    }
}