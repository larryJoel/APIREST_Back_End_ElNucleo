using System;
using System.Collections.Generic;

namespace backend_Blog_API.Models;

public partial class Post
{
    public int Id { get; set; }

    public string? Titulo { get; set; }

    public string? Intro { get; set; }

    public string? Conclusion { get; set; }

    public string? Contenido { get; set; }

    public string? Autor { get; set; }

    public string? Image { get; set; }

    public int? CategoriaId { get; set; }

    public string? Status { get; set; }

    public int? Visitas { get; set; }

    public int? Likes { get; set; }

    public int? CantComentarios { get; set; }

    public DateTime? CreadoEn { get; set; }

    public DateTime? EditadoEn { get; set; }

    public virtual Categoria? Categoria { get; set; }

    public virtual ICollection<Comentario> Comentarios { get; set; } = new List<Comentario>();
}
