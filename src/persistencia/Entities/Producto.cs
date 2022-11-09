namespace Aranda.Persistencia.Entities;

public partial class Producto
{
    public int Id { get; set; }
    public int CategoriaId { get; set; }
    public string? Nombre { get; set; }
    public string? Descripcion { get; set; }
    public string? Imagen { get; set; }

    public virtual Categoria Categoria { get; set; } = null!;
}