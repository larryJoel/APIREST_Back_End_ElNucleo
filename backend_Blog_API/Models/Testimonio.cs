using System;
using System.Collections.Generic;

namespace backend_Blog_API.Models;

public partial class Testimonio
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Cargo { get; set; }

    public DateTime? Fecha { get; set; }

    public string? Recomendacion { get; set; }
}
