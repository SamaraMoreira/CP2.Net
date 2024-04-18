using CP2.Net.Data;
using CP2.Net.DTOs;
using CP2.Net.Models;
using CP2.Net.Views.User;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace CP2.Net.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;

        private readonly DataContext _dataContext;
        public UserController(ILogger<UserController> logger, DataContext dataContext)
        {
            _dataContext = dataContext;
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult IndexLogin()
        {
            return View();
        }

        public IActionResult Register(UserCP2 resquest)
        {
            var user = _dataContext.Usuarios.FirstOrDefault(x => x.Email == resquest.Email);
            if (user != null)
            {
                return BadRequest("Usuário ja existe");
            }
            UserCP2 newUser = new UserCP2
            {
                Id = resquest.Id,
                Email = resquest.Email,
                Name = resquest.Name,
                Password = resquest.Password,
                Phone = resquest.Phone,
            };
            _dataContext.Add(newUser);
            _dataContext.SaveChanges();
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



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
