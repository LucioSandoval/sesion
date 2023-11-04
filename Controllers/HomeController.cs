using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Session.Models;

namespace Session.Controllers;

public class HomeController : Controller
{   
    private List<User> usuarios; // Declaración de la lista de usuarios

        public HomeController()
        {
            usuarios = new List<User>(); // Inicialización de la lista en el constructor

            // Crear y agregar 5 usuarios a la lista
            User user1 = new User
            {
                Nombre = "Luciana",
                Apellidos = "Apellido1",
                Edad = 25,
                CorreoElectronico = "usuario1@example.com",
                Contrasena = "password1"
            };
            usuarios.Add(user1);

            User user2 = new User
            {
                Nombre = "Lucia",
                Apellidos = "Apellido2",
                Edad = 30,
                CorreoElectronico = "usuario2@example.com",
                Contrasena = "password2"
            };
            usuarios.Add(user2);

            User user3 = new User
            {
                Nombre = "Lucio",
                Apellidos = "Apellido3",
                Edad = 28,
                CorreoElectronico = "usuario3@example.com",
                Contrasena = "password3"
            };
            usuarios.Add(user3);

            User user4 = new User
            {
                Nombre = "Jose",
                Apellidos = "Apellido4",
                Edad = 35,
                CorreoElectronico = "usuario4@example.com",
                Contrasena = "password4"
            };
            usuarios.Add(user4);

            User user5 = new User
            {
                Nombre = "Juan",
                Apellidos = "Apellido5",
                Edad = 27,
                CorreoElectronico = "usuario5@example.com",
                Contrasena = "password5"
            };
            usuarios.Add(user5);
        }
    

    private readonly ILogger<HomeController> _logger;

    public IActionResult Index()
    {   
                    
        return View();
    }

   [HttpPost]
   [Route("/nombre")]
    public IActionResult BuscarUsuario(string nombre)
    {   
            foreach(User user in usuarios){
                Console.WriteLine("NOMBREEEEEEEEEEEEE");
                Console.WriteLine(user.Nombre);
                if(user.Nombre == nombre ){
                    HttpContext.Session.SetString("Nombre", nombre);
                    Console.WriteLine("Entre a la sesionnnnnnnnnnn");
                    /* HttpContext.Session.SetString("Nombre", director.Nombre);
                    HttpContext.Session.SetString("Apellido", director.Apellido);
                    HttpContext.Session.SetString("Email", director.Email); */
                    return RedirectToAction("Privacy");
                }
            }
            Console.WriteLine("No a la sesionnnnnnnnnnn");
        return RedirectToAction("Privacy");
    } 

    public IActionResult Privacy()
    { 

        return View("Privacy", usuarios);
    }

    [HttpGet]
   [Route("/cerrarSesion")]
    public IActionResult CerrarSesion()
{   
    Console.WriteLine("CERRE SESION");
    HttpContext.Session.Clear(); // Elimina todos los datos de la sesión
    return View("Index"); // Redirige al usuario a la página de inicio o donde desees
}

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
