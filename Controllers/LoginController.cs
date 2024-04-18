using CP2.Net.Data;
using CP2.Net.DTOs;
using CP2.Net.Views.Login;
using Microsoft.AspNetCore.Mvc;

namespace CP2.Net.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;

        private readonly DataContext _dataContext;
        public LoginController(ILogger<LoginController> logger, DataContext dataContext)
        {
            _dataContext = dataContext;
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(LoginDTO request)
        {
            var find = _dataContext.Usuarios.FirstOrDefault(x => x.Email == request.Email);
            if (find == null)
            {
                return NotFound();
            }
            if (find.Password != request.Password)
            {
                return BadRequest("Senha inválida");
            }
            return View("Login", new LoginModel());
        }

    }
}
