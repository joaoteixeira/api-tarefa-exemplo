using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiTarefas2.Controllers
{
    [Route("/")]
    [ApiController]
    public class PrincipalController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("API Tarefas: online");
        }

        [HttpGet("hello-world")]
        public IActionResult GetHelloWorld()
        {
            return Ok("Hello World do João");
        }

        [HttpGet("autor")]
        public IActionResult GetAutor()
        {
            return Ok("Desenvolvido por João");
        }

    }
}
