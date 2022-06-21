using Microsoft.AspNetCore.Mvc;

namespace soothlyAPI.Controllers
{
    [ApiController]
    [Route("/")]
    public class HomeController : ControllerBase
    {
       [HttpGet]
       public ActionResult Inicio()
       {
         return new ContentResult
         {
             ContentType = "text/html",
             Content = "<h1>API Projeto Escola: funcionou!!!!</h1>"
         };
       }
    }
}