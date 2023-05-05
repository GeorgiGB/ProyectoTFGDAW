using Microsoft.EntityFrameworkCore;

namespace ProyectoTFG.Models
{
    public class UsuariosDbContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Data Source=PC-GGB-MASTER\\SQLEXPRESS;Initial Catalog=DbHospitalSaludTotalTFG;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
    }
}
