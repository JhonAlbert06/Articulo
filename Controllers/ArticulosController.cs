using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Articulo.Data;
using Articulo.Models;

namespace Articulo.Controllers;

[ApiController]
[Route("api/[controller]")]

public class ArticulosController : Controller
{
    private Contexto _contexto;

    public ArticulosController(Contexto contexto)
    {
        _contexto = contexto;
    }

    // GET: api/Articulos
    [HttpGet]
    [Route("")]
    public async Task<ActionResult<List<Articulos>>> GetArticulos()
    {//await
        return  _contexto.Articulos.ToListAsync();
    }

    // GET: api/Articulos/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Articulos>> GetArticulos(int id)
    {
        var articulos = await _contexto.Articulos.FindAsync(id);

        if (articulos == null)
        {
            return NotFound();
        }

        return articulos;
    }

    // PUT: api/Articulos/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutArticulos(int id, Articulos articulos)
    {
        if (id != articulos.AriticuloId)
        {
            return BadRequest();
        }

        _contexto.Entry(articulos).State = EntityState.Modified;

        try
        {
            await _contexto.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ArticulosExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // POST: api/Articulos
    [HttpPost]
    public async Task<ActionResult<Articulos>> PostArticulos(Articulos articulos)
    {
        _contexto.Articulos.Add(articulos);
        await _contexto.SaveChangesAsync();

        return CreatedAtAction("GetArticulos", new { id = articulos.AriticuloId }, articulos);
    }

    // DELETE: api/Articulos/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteArticulos(int id)
    {
        var articulos = await _contexto.Articulos.FindAsync(id);
        if (articulos == null)
        {
            return NotFound();
        }

        _contexto.Articulos.Remove(articulos);
        await _contexto.SaveChangesAsync();

        return NoContent();
    }

    private bool ArticulosExists(int id)
    {
        return _contexto.Articulos.Any(e => e.AriticuloId == id);
    }


}