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
    }
}