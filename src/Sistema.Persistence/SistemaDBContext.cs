using System.Globalization;
using Bogus;
using Microsoft.EntityFrameworkCore;
using Sistema.Domain;

namespace Sistema.Persistence;

public class SistemaDBContext : DbContext
{
    public DbSet<Curso>? Cursos {get; set; }
    public DbSet<Precio>? Precios {get; set;}
    public DbSet<Instructor>? Instructores {get;set;}
    public DbSet<Calificacion>? Calificaciones {get;set;}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=LocalDatabase.db")
        .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name },
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
        .Property(x => x.PrecioActual)
        .HasPrecision(10, 2);//10 enteros y 2 decimales
        modelBuilder.Entity<Precio>()
        .Property(x => x.PrecioPromocion)
        .HasPrecision(10, 2);//10 enteros y 2 decimales
        modelBuilder.Entity<Precio>()
        .Property(x => x.Nombre)
        .HasColumnType("VARCHAR")
        .HasMaxLength(250);

        modelBuilder.Entity<Curso>()
        .HasMany(t => t.Photos)
        .WithOne(t => t.Curso)
        .HasForeignKey(m => m.CursoId)
        .IsRequired()
        .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Curso>()
        .HasMany(m => m.Calificaciones)
        .WithOne(m => m.Curso)
        .HasForeignKey(m => m.CursoId)
        .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Curso>()
        .HasMany(m => m.Precios)
        .WithMany(m => m.Cursos)
        .UsingEntity<CursoPrecio>(
            j => j
            .HasOne(m => m.Precio)
            .WithMany(m => m.CursoPrecios)
            .HasForeignKey(m => m.PrecioId),
            j => j
            .HasOne(m => m.Curso)
            .WithMany(m => m.CursoPrecios)
            .HasForeignKey(m => m.CursoId),
            j =>
            {
                j.HasKey(t => new { t.PrecioId, t.CursoId });//se asigna clave primaria compuesta por el id de las claves foraneas
            }
        );
        modelBuilder.Entity<Curso>()
        .HasMany(m => m.Instructores)
        .WithMany(m => m.Cursos)
        .UsingEntity<CursoInstructor>(
            j => j
            .HasOne(e => e.Instructor)
            .WithMany(e => e.CursoInstructores)
            .HasForeignKey(e => e.InstructorId),
            j => j
            .HasOne(e => e.Curso)
            .WithMany(e => e.CursoInstructores)
            .HasForeignKey(e => e.CursoId),
            j =>
            {
                j.HasKey(t => new { t.InstructorId, t.CursoId });
            }
        );
        modelBuilder.Entity<Curso>().HasData(DataMaster().Item1);
        modelBuilder.Entity<Precio>().HasData(DataMaster().Item2);
        modelBuilder.Entity<Instructor>().HasData(DataMaster().Item3);


    }

    public Tuple<Curso[], Precio[], Instructor[]> DataMaster()
    {
        var cursos = new List<Curso>();
        var faker = new Faker();
        for (var i = 1; i < 10; i++)
        {
            var cursoId = Guid.NewGuid();
            cursos.Add(new Curso
            {
                Id = cursoId,
                Descripcion = faker.Commerce.ProductDescription(),
                Titulo = faker.Commerce.ProductName(),
                FechaPublicacion = DateTime.UtcNow

            });
        }
        var precioId = Guid.NewGuid();
        var precio = new Precio
        {
            Id = precioId,
            PrecioActual = 10.0m,
            PrecioPromocion = 8.0m,
            Nombre = "Precio standard"
        };
        var precios = new List<Precio>{
            precio
        };
        var fakerInstructor = new Faker<Instructor>()
        .RuleFor(t => t.Id, _ => Guid.NewGuid())
        .RuleFor(t => t.Nombre, f => f.Name.FirstName())
        .RuleFor(t=>t.Apellidos, f=>f.Name.LastName())
        .RuleFor(t=>t.Grado,f=>f.Name.JobTitle());
        var instructores = fakerInstructor.Generate(10);

        return Tuple.Create(cursos.ToArray(), precios.ToArray(),instructores.ToArray());
    }
}