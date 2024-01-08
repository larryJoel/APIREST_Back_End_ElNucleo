using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend_Blog_API.Models;

namespace backend_Blog_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly BlogElNucleoContext _context;
        public CategoriaController(BlogElNucleoContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var ListaCategorias = await _context.Categorias.ToListAsync();
            return Ok(ListaCategorias);
        }

        [HttpGet]
        [Route("Lista/{id:int}")]
        public async Task<IActionResult> Lista(int id)
        {
            var Categoria = await _context.Categorias.FindAsync(id);
            if (Categoria == null)
            {
                return BadRequest("No existe categoria");
            }
            else
            {
                return Ok(Categoria);
            }
        }

        [HttpPost]
        [Route("Agregar")]
        public async Task<IActionResult> Agregar([FromBody] Categoria res)
        {
            await _context.Categorias.AddAsync(res);
            await _context.SaveChangesAsync();
            return Ok(res);
        }

        [HttpPut]
        [Route("Editar/{id:int}")]
        public async Task<IActionResult> Editar(int id, [FromBody] Categoria categoria)
        {
            var res = _context.Categorias.Find(id);
            if (res == null)
            {
                return BadRequest("La categoria no existe");
            }
            else
            {
                res.Nombre = categoria.Nombre;
                res.Descripcion = categoria.Descripcion;
                await _context.SaveChangesAsync();
                return Ok(res);
            }

        }

        [HttpDelete]
        [Route("Eliminar/{id:int}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var res = await _context.Categorias.FindAsync(id);
            if (res == null)
            {
                return BadRequest("No existe la categoria");
            }
            else
            {
                _context.Categorias.Remove(res);
                await _context.SaveChangesAsync();
                return Ok("Categoria eliminada");

            }

        }


    }
}
