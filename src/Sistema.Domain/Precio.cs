namespace Sistema.Domain;
public class Precio:BaseEntity
{
    public string? Nombre { get; set; }
    public decimal PrecioActual {get; set; }
    public decimal PrecioPromocion {get; set; }
}