﻿namespace Aranda.Persistencia.Entities;

public partial class Categoria
{
    public Categoria()
    {
        Productos = new HashSet<Producto>();
    }

    public int Id { get; set; }
    public string? Nombre { get; set; }

    public virtual ICollection<Producto> Productos { get; set; }
}
