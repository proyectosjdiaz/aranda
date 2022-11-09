using Aranda.Negocio.DTO;

namespace Aranda.Negocio.Abstracciones;

public interface ICategoriaReglas
{
    Task<CategoriaDTO> Crear(CategoriaDTO categoria);
    Task<CategoriaDTO> Actualizar(CategoriaDTO categoria);
    Task<bool> Eliminar(int id);
    Task<IEnumerable<CategoriaDTO>> Categorias();
    Task<CategoriaDTO> Categoria(int id);
}
