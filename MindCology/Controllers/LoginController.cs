using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MindCology.DAL;
using MindCology.ViewModels.Login;


namespace MindCology.Controllers
{
    [ApiController]
    [Route("controller/login")]
    public class LoginController : ControllerBase
    {
        private MindCologyContext _mindCologyContext;

        public LoginController(MindCologyContext mindCologyContext)
        {
            _mindCologyContext = mindCologyContext;

        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(LoginModel model)
        {
            object response = _mindCologyContext.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _mindCologyContext.GetAll();
            return Ok(users);
        }
    }
}
