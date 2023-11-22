using Microsoft.AspNetCore.Mvc;

namespace MiPrimerAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[Action]")]
    public class ApiController : ControllerBase
    {       

        [HttpPost(Name = "SaveUser")]
        public int Multiplicacion(int a , int b)
        {
            return a * b;
        }
    }
}