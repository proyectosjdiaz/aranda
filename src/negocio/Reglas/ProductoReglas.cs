using Aranda.Negocio.Abstracciones;
using Aranda.Negocio.DTO;
using Aranda.Persistencia.Context;
using Aranda.Persistencia.Entities;
using Microsoft.EntityFrameworkCore;

namespace Aranda.Negocio.Reglas;

public class ProductoReglas : IProductoReglas
{
    private readonly ArandaDbContext context;

    public ProductoReglas(ArandaDbContext context)
    {
        this.context = context;
    }

    public async Task<IEnumerable<ProductoDTO>> Productos()
    {
        return await context.Productos
            .Include(p => p.Categoria)
            .Select(p => new ProductoDTO
            {
                Id = p.Id,
                CategoriaId = p.CategoriaId,
                Categoria = p.Categoria.Nombre,
                Nombre = p.Nombre,
                Descripcion = p.Descripcion,
                Imagen = p.Imagen,
            }).ToListAsync();
    }

    public async Task<ProductoDTO> Producto(int id)
    {
        return await context.Productos
            .Include(p => p.Categoria)
            .Where(c => c.Id.Equals(id))
            .Select(p => new ProductoDTO
            {
                Id = p.Id,
                CategoriaId = p.CategoriaId,
                Categoria = p.Categoria.Nombre,
                Nombre = p.Nombre,
                Descripcion = p.Descripcion,
                Imagen = p.Imagen,
            }).FirstOrDefaultAsync();
    }

    public async Task<ProductoDTO> Crear(ProductoDTO productoDTO)
    {
        Producto entity = await context.Productos.FirstOrDefaultAsync(p => p.Nombre.Equals(productoDTO.Nombre));

        if (entity is null)
        {
            entity = new Producto
            {
                CategoriaId = productoDTO.CategoriaId,
                Nombre = productoDTO.Nombre,
                Descripcion = productoDTO.Descripcion,
                Imagen = productoDTO.Imagen
            };
            context.Productos.Add(entity);
            await context.SaveChangesAsync();
        }
        productoDTO.Id = entity.Id;

        return productoDTO;
    }

    public async Task<ProductoDTO> Actualizar(ProductoDTO productoDTO)
    {
        if (await context.Productos.FirstOrDefaultAsync(c => c.Id.Equals(productoDTO.Id)) is Producto entity)
        {
            entity.CategoriaId = productoDTO.CategoriaId;
            entity.Nombre = productoDTO.Nombre;
            entity.Imagen = productoDTO.Imagen;
            context.Productos.Update(entity);
            await context.SaveChangesAsync();
        }

        return productoDTO;
    }

    public async Task<bool> Eliminar(int id)
    {
        if (await context.Productos.FirstOrDefaultAsync(c => c.Id.Equals(id)) is Producto entity)
        {
            context.Productos.Remove(entity);
            await context.SaveChangesAsync();
        }

        return true;
    }
}
