using Microsoft.AspNetCore.Mvc;
using soothlyAPI.Data;
using soothlyAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace soothlyAPI.Controllers
{     
     [ApiController]
     [Route("api/[controller]")]

    public class UsuariosController : ControllerBase
    {
        private SoothlyContext _context;
        
        public UsuariosController(SoothlyContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<Usuarios>> GetAll()
        {
            return _context.Usuarios.ToList();
        }

       [HttpGet("{UsuarioId}")]
      public ActionResult<List<Usuarios>> Get(int UsuarioId)
      {
         try
         {
             var result = _context.Usuarios.Find(UsuarioId);
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
       public async Task<ActionResult> post(Usuarios model)
        {
          try
          {
              _context.Usuarios.Add(model);
              if(await _context.SaveChangesAsync() == 1)
              {
                  return Created($"/api/usuarios/{model.nome}", model);
              }
          }
          catch
          {
              return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no acesso ao banco de dados.");
          }
          return BadRequest();
        }


      [HttpDelete("{UsuarioId}")]
      public async Task<ActionResult> delete(int UsuarioId)
      {
        try
        {
            //Verificação se existe o aluno a ser excluido
             var usuario = await _context.Usuarios.FindAsync(UsuarioId);
             if(usuario == null)
             {
                 return NotFound();
             }
             _context.Remove(usuario);
             await _context.SaveChangesAsync();
             return NoContent();
        }
        catch
        {
              return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no acesso ao banco de dados.");
        }
      }

      [HttpPut("{UsuarioId}")]
      public async Task<ActionResult> put(int UsuarioId, Usuarios dadosUsuarioAlt)
      {
          try
          {
              //Verificação se existe o aluno a ser alterado
              var result =  _context.Usuarios.Find(UsuarioId);
              if(result.id != UsuarioId)
              {
                  BadRequest();
              }
              result.nome = dadosUsuarioAlt.nome;
              result.emaill = dadosUsuarioAlt.emaill;
              result.senha = dadosUsuarioAlt.senha;
             
              await _context.SaveChangesAsync();
              return Created($"/api/curso/{dadosUsuarioAlt.id}", dadosUsuarioAlt);
          }
          catch
          {
              return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no acesso ao banco de dados.");
          }
      }
    }
}