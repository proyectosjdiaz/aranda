using Aranda.Negocio.DTO;

namespace Aranda.Negocio.Abstracciones;

public interface IProductoReglas
{
    Task<ProductoDTO> Crear(ProductoDTO producto);
    Task<ProductoDTO> Actualizar(ProductoDTO producto);
    Task<bool> Eliminar(int id);
    Task<IEnumerable<ProductoDTO>> Productos();
    Task<ProductoDTO> Producto(int id);
}
