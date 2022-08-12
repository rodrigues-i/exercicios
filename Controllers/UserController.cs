using CrudClientes.Models;
using CrudClientes.Services;
using Microsoft.AspNetCore.Mvc;

namespace CrudClientes.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController: ControllerBase
{
    public UserController()
    {

    }

    [HttpGet]
    public ActionResult<List<User>> GetAll() =>
        UserService.GetAll();
}