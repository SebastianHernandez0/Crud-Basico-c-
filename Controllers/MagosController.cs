using MagosHogwarts.DTOs;
using MagosHogwarts.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MagosHogwarts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MagosController : ControllerBase
    {
        private Context _context;

        public MagosController(Context context)
        {
            _context = context;
        }

        [HttpGet]

        public async Task<IEnumerable<MagoDto>> Get()
        {
            return await _context.Magos.Select(x => new MagoDto
            {
                Id = x.Id,
                Nombre = x.Nombre,
                CasaId = x.CasaId,
                Imagen = x.Imagen,
                Wiki = x.Wiki
            }).ToListAsync();
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<MagoDto>> GetById(int id)
        {
            var mago = await _context.Magos.FindAsync(id);

            if (mago == null)
            {
                return NotFound();
            }
            var magoDto = new MagoDto
            {
                Id = mago.Id,
                Nombre = mago.Nombre,
                CasaId = mago.CasaId,
                Imagen = mago.Imagen,
                Wiki = mago.Wiki
            };

            return Ok(magoDto);
        }

        [HttpPost]
        public async Task<ActionResult<MagoDto>> Add(MagoInsertDto magoInsertDto)
        {
            var mago = new Magos
            {
                Nombre = magoInsertDto.Nombre,
                CasaId = magoInsertDto.CasaId,
                Imagen = magoInsertDto.Imagen,
                Wiki = magoInsertDto.Wiki
            };

            await _context.Magos.AddAsync(mago);
            await _context.SaveChangesAsync();

            var magoDto = new MagoDto
            {
                Id = mago.Id,
                Nombre = mago.Nombre,
                CasaId = mago.CasaId,
                Imagen = mago.Imagen,
                Wiki = mago.Wiki
            };

            return CreatedAtAction(nameof(GetById), new { id = mago.Id }, magoDto);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult<MagoDto>> Update(int id, MagoUpdateDto magoUpdateDto)
        {
            var mago = await _context.Magos.FindAsync(id);

            if(mago == null)
            {
                return NotFound();
            }

            mago.Nombre = magoUpdateDto.Nombre;
            mago.CasaId = magoUpdateDto.CasaId;
            mago.Imagen = magoUpdateDto.Imagen;
            mago.Wiki = magoUpdateDto.Wiki;

            await _context.SaveChangesAsync();

            var magoDto = new MagoDto
            {
                Id = mago.Id,
                Nombre = mago.Nombre,
                CasaId = mago.CasaId,
                Imagen = mago.Imagen,
                Wiki = mago.Wiki
            };
            return Ok(magoDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var mago = await _context.Magos.FindAsync(id);
            if (mago == null)
            {
                return NotFound();
            }
            _context.Magos.Remove(mago);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}


