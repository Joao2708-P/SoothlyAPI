using Microsoft.AspNetCore.Mvc;
using soothlyAPI.Data;
using soothlyAPI.Models;

namespace soothlyAPI.Controllers
{
     [Route("api/[controller]")]
     [ApiController]
    public class ArtigosController : ControllerBase
    {
       SoothlyContext _context;
       public ArtigosController(SoothlyContext context)
       {
          _context = context;
       }  

       [HttpGet]
       public ActionResult<List<Artigos>> GetAll()
       {
           return _context.Artigos.ToList();
       }

       [HttpGet("{ArtigosId}")]
       public ActionResult<List<Artigos>> Get(int ArtigosId)
       {
         try
         {
             var result = _context.Artigos.Find(ArtigosId);
             if (result == null)
             {
               return NotFound();
             }
              return Ok(result);
         }
         catch
         { 
             return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no acesso ao banco de dados.");
         }
       }

       [HttpPost]
       public async Task<ActionResult> post(Artigos model)
       {
          try
          {
              _context.Artigos.Add(model);
              if(await _context.SaveChangesAsync() == 1)
              {
                  return Created($"/api/Artigos/{model.corpo}", model);
              }
          }
          catch 
          {
             return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no acesso ao banco de dados.");
          }
          return BadRequest();
       }

       [HttpDelete("{ArtigosId}")]
       public async Task<ActionResult> delete(int ArtigosId)
       {
          var artigo = await _context.Artigos.FindAsync(ArtigosId);
          if(artigo == null)
          {
             return NotFound();
          }
          _context.Artigos.Remove(artigo);
          await _context.SaveChangesAsync();
          return NoContent();
       }

       [HttpPut("{ArtigosId}")]
       public async Task<ActionResult> put(int ArtigosId, Artigos dadosArtigos)
       {
          try
          {
             var result = await _context.Artigos.FindAsync(ArtigosId);
             if(result.id != ArtigosId)
             {
                 return BadRequest();
             }
             result.corpo = dadosArtigos.corpo;
             await _context.SaveChangesAsync();
              return Created($"/api/artigos/{dadosArtigos.id}", dadosArtigos);
          }
          catch 
          {
             return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no acesso ao banco de dados.");
          }
       }
    }
}