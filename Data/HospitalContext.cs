using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace ProyectoTFG.Data;

public class HospitalContext : IdentityDbContext<IdentityUser>
{
    protected readonly IConfiguration _configuration;

    public HospitalContext(DbContextOptions<HospitalContext> options, IConfiguration configuration):base(options)
    {
        _configuration = configuration;
    }

    public DbSet<Atendido> Atendidos { get; set; }

    public DbSet<Cita> Citas { get; set; }

    public DbSet<Pacientes> Pacientes { get; set; }

    public DbSet<Trabajadores> Trabajadores { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DatosDb"));
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Atendido>(entity =>
        {
            entity.HasKey(e => new { e.TrabajadorId, e.PacienteId });

            entity.ToTable("Atendido");

            entity.Property(e => e.TrabajadorId).HasColumnType("int");
            entity.Property(e => e.PacienteId).HasColumnType("int");
        });

        modelBuilder.Entity<Cita>(entity =>
        {
            entity.HasKey(e => e.idCita)
                .HasName("PrimaryKey_idCita");

            entity.Property(e => e.idCita)
                .ValueGeneratedOnAdd()
                .HasColumnType("int")
                .HasColumnName("idCita");

            entity.Property(e => e.Duracion).HasColumnType("int");

            entity.Property(e => e.Fecha).HasColumnType("datetime");

            entity.Property(e => e.PacienteId)
                .HasColumnType("int")
                .HasColumnName("PacienteID");

            entity.Property(e => e.TrabajadorId)
                .HasColumnType("int")
                .HasColumnName("TrabajadorID");

            entity.Property(e => e.Estado)
                .HasColumnType("varchar(20)");
        });


        modelBuilder.Entity<Pacientes>(entity =>
        {
            entity.HasKey(e => e.idPac)
            .HasName("PrimaryKey_idPac");

			entity.Property(e => e.idPac)
				.ValueGeneratedOnAdd()
				.HasColumnType("int")
                .HasColumnName("idPac");
           
            entity.Property(e => e.PacApellido)
                .HasColumnType("varchar(50)")
                .HasColumnName("pacApellido");
            entity.Property(e => e.PacDireccion)
                .HasColumnType("varchar(100)")
                .HasColumnName("pacDireccion");
            entity.Property(e => e.PacFechRegistro)
                .HasColumnType("DATE")
                .HasColumnName("pacFechRegistro");
            entity.Property(e => e.PacGs)
                .HasColumnType("varchar(50)")
                .HasColumnName("pacGS");
            entity.Property(e => e.PacNombre)
                .HasColumnType("varchar(50)")
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
                .HasColumnType("int")
                 .HasColumnName("idTrab");
            entity.Property(e => e.TrabApellido)
                .HasColumnType("varchar(50)")
                .HasColumnName("trabApellido");
            entity.Property(e => e.TrabCorreo)
                .HasColumnType("varchar(50)")
                .HasColumnName("trabCorreo");
            entity.Property(e => e.TrabDireccion)
                .HasColumnType("varchar(100)")
                .HasColumnName("trabDireccion");
            entity.Property(e => e.TrabFechaContrato)
                .HasColumnType("DATE")
                .HasColumnName("trabFechaContrato");
            entity.Property(e => e.TrabHorario)
                .HasColumnType("varchar(50)")
                .HasColumnName("trabHorario");
            entity.Property(e => e.TrabNombre)
                .HasColumnType("varchar(50)")
                .HasColumnName("trabNombre");
            entity.Property(e => e.TrabPuesto)
                .HasColumnType("varchar(50)")
                .HasColumnName("trabPuesto");
            entity.Property(e => e.TrabSexo)
                .HasColumnType("varchar(50)")
                .HasColumnName("trabSexo");
            entity.Property(e => e.TrabTel)
                .HasColumnType("varchar(15)")
                .HasColumnName("trabTel");
        });
    }
}
