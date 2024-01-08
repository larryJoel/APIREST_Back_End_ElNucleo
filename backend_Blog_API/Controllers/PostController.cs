using backend_Blog_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend_Blog_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly BlogElNucleoContext _context;

        public PostController(BlogElNucleoContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Lista")]
        public IActionResult Lista()
        {
            var ListaBlog = _context.Posts.ToList();
            return Ok(ListaBlog);
        }

        [HttpGet]
        [Route("Lista/{id:int}")]
        public IActionResult Lista(int id)
        {
            var Blog = _context.Posts.Find(id);
            return Ok(Blog);
        }

        [HttpPost]
        [Route("Agregar")]
        public async Task<IActionResult> Agregar([FromBody] Post post)
        {
            await _context.Posts.AddAsync(post);
            await _context.SaveChangesAsync();
            return Ok(post);
        }

        [HttpPut]
        [Route("Editar/{id:int}")]
        public async Task<IActionResult> Editar(int id, [FromBody] Post post)
        {
            var res = _context.Posts.Find(id);
            if (res == null)
            {
                return BadRequest("No existe el Post");
            }
            else
            {
                res.Titulo = post.Titulo;
                res.Intro = post.Intro;
                res.Conclusion = post.Conclusion;
                res.Contenido = post.Contenido;
                res.Autor = post.Autor;
                res.Image = post.Image;
                res.CategoriaId = post.CategoriaId;
                res.Status = post.Status;
                res.Visitas = post.Visitas;
                res.Likes = post.Likes;
                res.CantComentarios = post.CantComentarios;
                res.CreadoEn = post.CreadoEn;
                res.EditadoEn = post.EditadoEn;
                await _context.SaveChangesAsync();
                return Ok(res);
            }
        }

        [HttpDelete]
        [Route("Eliminar/{id:int}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var res = await _context.Posts.FindAsync(id);
            if(res == null) 
            {
                return BadRequest("No exite el Post");
            }
            else
            {
                _context.Posts.Remove(res);
                await _context.SaveChangesAsync();
                return Ok("Post eliminado");
            }

        }


    }
}
