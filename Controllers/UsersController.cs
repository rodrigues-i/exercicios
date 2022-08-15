using CrudClientes.Models;
using CrudClientes.Services;
using Microsoft.AspNetCore.Mvc;
using CrudClientes.Repository;
using Microsoft.EntityFrameworkCore;

namespace CrudClientes.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController: ControllerBase
{
    private readonly IUserRepository _repository;

    public UsersController(IUserRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<List<User>>> GetAll()
    {
        return await _repository.GetUsers();
    }
        

    [HttpGet("{id}")]
    public ActionResult<User> Get(int id)
    {
        var user = UserService.GetById(id);
        if(user == null)
            return NotFound();
        return user;
    }

    [HttpPost]
    public async Task<IActionResult> Create(User user)
    {
        user.creationDate = DateTime.Now;
        _repository.AddUser(user);
        return await _repository.SaveChangesAsync()
        ? Ok("User created successfully")
        : BadRequest("Error while trying to add new user");
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

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var user = UserService.GetById(id);
        if(user is null)
            return NotFound();
        
        UserService.Delete(id);
        return NoContent();
    }
}