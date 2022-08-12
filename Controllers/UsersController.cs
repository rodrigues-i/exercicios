using CrudClientes.Models;
using CrudClientes.Services;
using Microsoft.AspNetCore.Mvc;

namespace CrudClientes.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController: ControllerBase
{
    public UsersController()
    {

    }

    [HttpGet]
    public ActionResult<List<User>> GetAll() =>
        UserService.GetAll();
    [HttpGet("{id}")]
    public ActionResult<User> Get(int id) {
        var user = UserService.GetById(id);
        if(user == null)
            return NotFound();
        return user;
    }
}