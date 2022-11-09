using Aranda.Negocio.Abstracciones;
using Aranda.Negocio.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Aranda.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaReglas categoriaReglas;

        public CategoriaController(ICategoriaReglas categoriaReglas)
        {
            this.categoriaReglas = categoriaReglas;
        }

        [HttpGet("categorias")]
        public async Task<IActionResult> Categorias()
        {
            try
            {
                var categorias = await categoriaReglas.Categorias();
                return Ok(categorias);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Categoria(int id)
        {
            try
            {
                var categoria = await categoriaReglas.Categoria(id);
                return Ok(categoria);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] CategoriaDTO categoriaDTO)
        {
            try
            {
                categoriaDTO = await categoriaReglas.Crear(categoriaDTO);
                return Ok(categoriaDTO);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Actualizar([FromBody] CategoriaDTO categoriaDTO)
        {
            try
            {
                categoriaDTO = await categoriaReglas.Actualizar(categoriaDTO);
                return Ok(categoriaDTO);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            try
            {
                bool success = await categoriaReglas.Eliminar(id);
                return Ok(success);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
