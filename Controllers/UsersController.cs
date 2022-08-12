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
    public ActionResult<User> Get(int id)
    {
        var user = UserService.GetById(id);
        if(user == null)
            return NotFound();
        return user;
    }

    [HttpPost]
    public IActionResult Create(User user)
    {
        if(user.age < 1)
            return BadRequest();

        UserService.Add(user);
        return CreatedAtAction(nameof(Create), new {id = user.id}, user);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, User user)
    {
        if(user.id != id)
            return BadRequest();
        var existingUser = UserService.GetById(id);
        if(existingUser is null)
            return NotFound();
        UserService.Update(user);

        return NoContent();
    }
}