using Aranda.Front.Model;

namespace Aranda.Front.Service
{
    public interface IServiceCategoria
    {
        Task<CategoriaModel> Categoria(int id);
        Task<IEnumerable<CategoriaModel>> Categorias();
        Task<CategoriaModel> Crear(CategoriaModel categoria);
        Task<CategoriaModel> Actualizar(CategoriaModel categoria);
        Task<bool> Eliminar(int id);
    }
}
