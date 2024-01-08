using System;
using System.Collections.Generic;

namespace backend_Blog_API.Models;

public partial class Categoria
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
}
