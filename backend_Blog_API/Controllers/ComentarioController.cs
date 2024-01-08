using backend_Blog_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend_Blog_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentarioController : ControllerBase
    {
        private readonly BlogElNucleoContext _context;
        public ComentarioController(BlogElNucleoContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Lista")]
        public IActionResult Lista() 
        {
            var ListaComent = _context.Comentarios.ToList();
            return Ok(ListaComent);
        }

        [HttpGet]
        [Route("Lista/{id:int}")]
        public IActionResult Lista(int id)
        {
            var comentario = _context.Comentarios.Find(id);
            if (comentario == null)
            {
                return BadRequest("No existe el comentario");
            }
            else
            {
                return Ok(comentario);
            }
        }

        [HttpGet]
        [Route("ListaPorPost/{postId:int}")]
        public async Task<IActionResult> ListaPorPost(int postId)
        {
            // Buscar comentarios por el PostId utilizando Entity Framework
            var comentarios = await _context.Comentarios
                                            .Where(c => c.PostId == postId)
                                            .ToListAsync();

            if (comentarios == null || comentarios.Count == 0)
            {
                return BadRequest("No existen comentarios sobre este post");
            }
            else
            {
                return Ok(comentarios);
            }
        }

        [HttpPost]
        [Route("Agregar")]
        public async Task<IActionResult> Agregar([FromBody] Comentario comentario)
        {
            await _context.Comentarios.AddAsync(comentario);
            await _context.SaveChangesAsync();
            return Ok(comentario);
        }

        [HttpPut]
        [Route("Editar/{id:int}")]
        public async Task<IActionResult> Editar(int id, [FromBody] Comentario comentario)
        {
            var res = _context.Comentarios.Find(id);
            if(res == null)
            {
                return BadRequest("No existe el comentario");
            }
            else
            {
                res.Nombre = comentario.Nombre;
                res.Email = comentario.Email;
                res.Comentario1 = comentario.Comentario1;
                res.PostId = comentario.PostId;
                res.CreadoEn = comentario.CreadoEn;
                res.EditadoEn = comentario.EditadoEn;
                await _context.SaveChangesAsync();
                return Ok(res);
            }
        }

        [HttpDelete]
        [Route("Eliminar/{id:int}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var res = await _context.Comentarios.FindAsync(id);
            if(res == null)
            {
                return BadRequest("No existe el comentario");
            }
            else
            {
                _context.Comentarios.Remove(res);
                await _context.SaveChangesAsync();
                return Ok("Comentario eliminado");
            }
        }

    }
}
