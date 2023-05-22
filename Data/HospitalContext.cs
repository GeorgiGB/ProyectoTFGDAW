using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProyectoTFG.Data;

public partial class HospitalContext : DbContext
{
    public HospitalContext()
    {
    }

    public HospitalContext(DbContextOptions<HospitalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Atendido> Atendidos { get; set; }

    public virtual DbSet<Cita> Citas { get; set; }

    public virtual DbSet<Pacientes> Pacientes { get; set; }

    public virtual DbSet<Trabajadores> Trabajadores { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=Data\\\\\\\\hospital.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Atendido>(entity =>
        {
            entity.HasKey(e => new { e.TrabajadorId, e.PacienteId });

            entity.ToTable("Atendido");

            entity.Property(e => e.TrabajadorId).HasColumnType("INT");
            entity.Property(e => e.PacienteId).HasColumnType("INT");
        });

        modelBuilder.Entity<Cita>(entity =>
        {
            entity.HasKey(e => e.IdCita);

            entity.Property(e => e.IdCita)
                .ValueGeneratedNever()
                .HasColumnType("INT")
                .HasColumnName("idCita");
            entity.Property(e => e.Duracion).HasColumnType("INT");
            entity.Property(e => e.Fecha).HasColumnType("DATETIME");
            entity.Property(e => e.PacienteId)
                .HasColumnType("INT")
                .HasColumnName("PacienteID");
            entity.Property(e => e.TrabajadorId)
                .HasColumnType("INT")
                .HasColumnName("TrabajadorID");
        });

        modelBuilder.Entity<Pacientes>(entity =>
        {
            entity.HasKey(e => e.Idpac);

            entity.Property(e => e.Idpac)
                .ValueGeneratedNever()
                .HasColumnType("INT")
                .HasColumnName("idpac");
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
            entity.HasKey(e => e.Idtrab);

            entity.Property(e => e.Idtrab)
                .ValueGeneratedNever()
                .HasColumnType("INT")
                .HasColumnName("idtrab");
            entity.Property(e => e.TrabApellido)
                .HasColumnType("VARCHAR(50)")
                .HasColumnName("trabApellido");
            entity.Property(e => e.TrabCorreo)
                .HasColumnType("VARCHAR(50)")
                .HasColumnName("trabCorreo");
            entity.Property(e => e.TrabDireccion)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("trabDireccion");
            entity.Property(e => e.TrabFechNa)
                .HasColumnType("DATE")
                .HasColumnName("trabFechNa");
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
                .HasColumnType("CHAR(1)")
                .HasColumnName("trabSexo");
            entity.Property(e => e.TrabTel)
                .HasColumnType("VARCHAR(15)")
                .HasColumnName("trabTel");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Idusu);

            entity.Property(e => e.Idusu)
                .ValueGeneratedNever()
                .HasColumnType("INT")
                .HasColumnName("idusu");
            entity.Property(e => e.UsuNombre)
                .HasColumnType("VARCHAR(50)")
                .HasColumnName("usuNombre");
            entity.Property(e => e.UsuPwd)
                .HasColumnType("VARCHAR(50)")
                .HasColumnName("usuPwd");
            entity.Property(e => e.UsuRol)
                .HasColumnType("VARCHAR(20)")
                .HasColumnName("usuRol");
            entity.Property(e => e.UsuTrabId)
                .HasColumnType("INT")
                .HasColumnName("usuTrabId");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
