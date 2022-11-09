namespace Aranda.Front.Model
{
    public class ProductoModel
    {
        public int Id { get; set; }
        public int CategoriaId { get; set; }
        public string? Categoria { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public string? Imagen { get; set; }
    }
}
