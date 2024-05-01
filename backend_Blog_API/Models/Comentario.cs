using System;
using System.Collections.Generic;

namespace backend_Blog_API.Models;

public partial class Comentario
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Email { get; set; }

    public string? Comentar { get; set; }

    public int? PostId { get; set; }

    public DateTime? CreadoEn { get; set; }

    public DateTime? EditadoEn { get; set; }

    public virtual Post? Post { get; set; }
}
