using Microsoft.EntityFrameworkCore;
using Sistema.Domain;

namespace Sistema.Persistence;

public class SistemaDBContext:DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=LocalDatabase.db")
        .LogTo(Console.WriteLine, new [] {DbLoggerCategory.Database.Command.Name},
        Microsoft.Extensions.Logging.LogLevel.Information
        ).EnableSensitiveDataLogging();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Curso>().ToTable("cursos");
        modelBuilder.Entity<Instructor>().ToTable("instructores");
        modelBuilder.Entity<CursoInstructor>().ToTable("curso_instructores");
        modelBuilder.Entity<Calificacion>().ToTable("calificaciones");
        modelBuilder.Entity<Precio>().ToTable("precios");
        modelBuilder.Entity<CursoPrecio>().ToTable("curso_precios");
        modelBuilder.Entity<Photo>().ToTable("imagenes");

        modelBuilder.Entity<Precio>()
        .Property(x=>x.PrecioActual)
        .HasPrecision(10,2);//10 enteros y 2 decimales
        modelBuilder.Entity<Precio>()
        .Property(x=>x.PrecioPromocion)
        .HasPrecision(10,2);//10 enteros y 2 decimales
        modelBuilder.Entity<Precio>()
        .Property(x=>x.Nombre)
        .HasColumnType("VARCHAR")
        .HasMaxLength(250);

        modelBuilder.Entity<Curso>()
        .HasMany(t=>t.Photos)
        .WithOne(t=>t.Curso)
        .HasForeignKey(m=>m.CursoId)
        .IsRequired()
        .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<Curso>()
        .HasMany(m=>m.Calificaciones)
        .WithOne(m=>m.Curso)
        .HasForeignKey(m=>m.CursoId)
        .OnDelete(DeleteBehavior.Restrict);

    }
}