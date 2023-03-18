using Microsoft.AspNetCore.Mvc;

namespace FreesomeServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BackendController : ControllerBase
    {
        [HttpGet("MakeDraw")]
        public void MakeDraw(string authentication)
        {
            if (authentication == AuthenticationKey.Passcode)
                ServerLogic.MakeDraw();
        }
    }
}
