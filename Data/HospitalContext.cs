using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace ProyectoTFG.Data;

public class HospitalContext : IdentityDbContext<IdentityUser>
{
    protected readonly IConfiguration Configuration;

    public DbSet<Atendido> Atendidos { get; set; }

    public DbSet<Cita> Citas { get; set; }

    public DbSet<Pacientes> Pacientes { get; set; }

    public DbSet<Trabajadores> Trabajadores { get; set; }

    public HospitalContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.
            EnableSensitiveDataLogging()
            .UseSqlite("Data Source=Data\\\\\\\\hospital.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Atendido>(entity =>
        {
            entity.HasKey(e => new { e.TrabajadorId, e.PacienteId });

            entity.ToTable("Atendido");

            entity.Property(e => e.TrabajadorId).HasColumnType("INTEGER");
            entity.Property(e => e.PacienteId).HasColumnType("INTEGER");
        });

        modelBuilder.Entity<Cita>(entity =>
        {
            entity.HasKey(e => e.idCita)
                .HasName("PrimaryKey_idCita");

            entity.Property(e => e.idCita)
                .ValueGeneratedOnAdd()
                .HasColumnType("INTEGER")
                .HasColumnName("idCita");

            entity.Property(e => e.Duracion).HasColumnType("INTEGER");

            entity.Property(e => e.Fecha).HasColumnType("DATETIME");

            entity.Property(e => e.PacienteId)
                .HasColumnType("INTEGER")
                .HasColumnName("PacienteID");

            entity.Property(e => e.TrabajadorId)
                .HasColumnType("INTEGER")
                .HasColumnName("TrabajadorID");

            entity.Property(e => e.Estado)
                .HasColumnType("VARCHAR(20)");
        });


        modelBuilder.Entity<Pacientes>(entity =>
        {
            entity.HasKey(e => e.idPac)
            .HasName("PrimaryKey_idPac");

			entity.Property(e => e.idPac)
				.ValueGeneratedOnAdd()
				.HasColumnType("INTEGER")
                .HasColumnName("idPac");
           
            entity.Property(e => e.PacApellido)
                .HasColumnType("VARCHAR(50)")
                .HasColumnName("pacApellido");
            entity.Property(e => e.PacDireccion)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("pacDireccion");
            entity.Property(e => e.PacFechRegistro)
                .HasColumnType("DATE")
                .HasColumnName("pacFechRegistro");
            entity.Property(e => e.PacGs)
                .HasColumnType("VARCHAR(50)")
                .HasColumnName("pacGS");
            entity.Property(e => e.PacNombre)
                .HasColumnType("VARCHAR(50)")
                .HasColumnName("pacNombre");
            entity.Property(e => e.PacSexo)
                .HasColumnType("CHAR(1)")
                .HasColumnName("pacSexo");
        });

        modelBuilder.Entity<Trabajadores>(entity =>
        {
            entity.HasKey(e => e.idTrab)
                .HasName("PrimaryKey_idTrab");

            entity.Property(e => e.idTrab)
                .ValueGeneratedOnAdd()
                .HasColumnType("INTEGER")
                 .HasColumnName("idTrab");
            entity.Property(e => e.TrabApellido)
                .HasColumnType("VARCHAR(50)")
                .HasColumnName("trabApellido");
            entity.Property(e => e.TrabCorreo)
                .HasColumnType("VARCHAR(50)")
                .HasColumnName("trabCorreo");
            entity.Property(e => e.TrabDireccion)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("trabDireccion");
            entity.Property(e => e.TrabFechaContrato)
                .HasColumnType("DATE")
                .HasColumnName("trabFechaContrato");
            entity.Property(e => e.TrabHorario)
                .HasColumnType("VARCHAR(50)")
                .HasColumnName("trabHorario");
            entity.Property(e => e.TrabNombre)
                .HasColumnType("VARCHAR(50)")
                .HasColumnName("trabNombre");
            entity.Property(e => e.TrabPuesto)
                .HasColumnType("VARCHAR(50)")
                .HasColumnName("trabPuesto");
            entity.Property(e => e.TrabSexo)
                .HasColumnType("VARCHAR(50)")
                .HasColumnName("trabSexo");
            entity.Property(e => e.TrabTel)
                .HasColumnType("VARCHAR(15)")
                .HasColumnName("trabTel");
        });
    }
}
