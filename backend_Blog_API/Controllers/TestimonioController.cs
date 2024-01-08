using backend_Blog_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace backend_Blog_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonioController : ControllerBase
    {
        private readonly BlogElNucleoContext _context;

        public TestimonioController(BlogElNucleoContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Lista")]
        public IActionResult Get()
        {
            var ListaTestim = _context.Testimonios.ToList();
            return Ok(ListaTestim);
        }

        [HttpGet]
        [Route("Lista/{id:int}")]
        public async Task<IActionResult> Lista(int id)
        {
            var Testimonio = await _context.Testimonios.FindAsync(id);
            return Ok(Testimonio);
        }

        [HttpPost]
        [Route("Agregar")]
        public async Task<IActionResult> Agregar([FromBody] Testimonio testimonio)
        {
            await _context.Testimonios.AddAsync(testimonio);
            await _context.SaveChangesAsync();
            return Ok(testimonio);
        }

        [HttpPut]
        [Route("Editar/{id:int}")]
        public async Task<IActionResult> Editar(int id, [FromBody] Testimonio testimonio)
        {
            var res = _context.Testimonios.Find(id);
            if (res == null)
            {
                return BadRequest("El testimonio no exite");
            }
            else
            {
                res.Nombre = testimonio.Nombre;
                res.Cargo = testimonio.Cargo;
                res.Fecha = testimonio.Fecha;
                res.Recomendacion = testimonio.Recomendacion;
                await _context.SaveChangesAsync();
                return Ok(testimonio);
            }
        }

        [HttpDelete]
        [Route("Eliminar/{id:int}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var res = await _context.Testimonios.FindAsync(id);
            if (res == null)
            {
                return BadRequest("La recomendación no existe");
            }
            else
            {
                _context.Testimonios.Remove(res);
                await _context.SaveChangesAsync();
                return Ok("testimonio eliminado");
            }
        }
    }
}
