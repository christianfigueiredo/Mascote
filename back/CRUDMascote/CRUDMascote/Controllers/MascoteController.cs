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
        

    }  
        
}
