using CRUDMascote.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUDMascote.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MascoteController : ControllerBase
    {
        private readonly Contexto _contexto;

        public MascoteController(Contexto contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var listMascote = await _contexto.Mascotes.ToListAsync();
                return Ok(listMascote);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var mascote = await _contexto.Mascotes.FirstOrDefaultAsync(m => m.Id == id);
                if (mascote == null)
                    return NotFound();
                return Ok(mascote);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var delmascote = await _contexto.Mascotes.FirstOrDefaultAsync(m => m.Id == id);

                if (delmascote == null)
                    return NotFound();

                _contexto.Mascotes.Remove(delmascote);
                await _contexto.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Criar(Mascote mascote)
        {
            try
            {
                mascote.DataCriacao = DateTime.Now;
                _contexto.Mascotes.AddAsync(mascote);
                await _contexto.SaveChangesAsync();
               
                return CreatedAtAction("Get", new {id = mascote.Id}, mascote);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

}
