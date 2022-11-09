using Aranda.Negocio.Abstracciones;
using Aranda.Negocio.DTO;
using Aranda.Persistencia.Context;
using Aranda.Persistencia.Entities;
using Microsoft.EntityFrameworkCore;

namespace Aranda.Negocio.Reglas;

public class CategoriaReglas : ICategoriaReglas
{
    private readonly ArandaDbContext context;

    public CategoriaReglas(ArandaDbContext context)
    {
        this.context = context;
    }

    public async Task<IEnumerable<CategoriaDTO>> Categorias()
    {
        return await context.Categoria
            .Select(c => new CategoriaDTO
            {
                Id = c.Id,
                Nombre = c.Nombre
            }).ToListAsync();
    }

    public async Task<CategoriaDTO> Categoria(int id)
    {
        return await context.Categoria
            .Where(c => c.Id.Equals(id))
            .Select(c => new CategoriaDTO
            {
                Id = c.Id,
                Nombre = c.Nombre
            }).FirstOrDefaultAsync();
    }

    public async Task<CategoriaDTO> Crear(CategoriaDTO categoriaDTO)
    {
        Categoria entity = await context.Categoria.FirstOrDefaultAsync(c => c.Nombre.Equals(categoriaDTO.Nombre));

        if (entity is null)
        {
            entity = new Categoria
            {
                Nombre = categoriaDTO.Nombre,
            };
            context.Categoria.Add(entity);
            await context.SaveChangesAsync();
        }
        categoriaDTO.Id = entity.Id;

        return categoriaDTO;
    }

    public async Task<CategoriaDTO> Actualizar(CategoriaDTO categoriaDTO)
    {
        if (await context.Categoria.FirstOrDefaultAsync(c => c.Id.Equals(categoriaDTO.Id)) is Categoria entity)
        {
            entity.Nombre = categoriaDTO.Nombre;
            context.Categoria.Update(entity);
            await context.SaveChangesAsync();
        }

        return categoriaDTO;
    }

    public async Task<bool> Eliminar(int id)
    {
        if (await context.Categoria.FirstOrDefaultAsync(c => c.Id.Equals(id)) is Categoria entity)
        {
            context.Categoria.Remove(entity);
            await context.SaveChangesAsync();
        }

        return true;
    }
}
