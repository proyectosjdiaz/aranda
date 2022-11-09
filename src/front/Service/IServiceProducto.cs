using Aranda.Front.Model;

namespace Aranda.Front.Service
{
    public interface IServiceProducto
    {
        Task<ProductoModel> Producto(int id);
        Task<IEnumerable<ProductoModel>> Productos();
        Task<ProductoModel> Crear(ProductoModel producto);
        Task<ProductoModel> Actualizar(ProductoModel producto);
        Task<bool> Eliminar(int id);
    }
}
