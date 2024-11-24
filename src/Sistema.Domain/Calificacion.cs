namespace Sistema.Domain;
public class Calificacion:BaseEntity
{

    public string? Alumno { get; set; }
    public int Puntaje {get; set;}
    public string? Comentario { get; set;}
}