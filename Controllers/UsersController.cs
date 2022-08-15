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
    public async Task<ActionResult<User>> Get(int id)
    {
        var Dbuser = await _repository.GetUserById(id);
        if(Dbuser == null)
            return NotFound("User not found");
        
        return Ok(Dbuser);
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
    public async Task<ActionResult<User>> Update(int id, User user)
    {
        var Dbuser = await _repository.GetUserById(id);
        if(Dbuser == null)
            return BadRequest("User not found");
        
        Dbuser.firstName = user.firstName ?? Dbuser.firstName;
        Dbuser.surname = user.surname ?? Dbuser.surname;
        Dbuser.age = user.age ?? Dbuser.age;

         _repository.UpdateUser(Dbuser);

         return await _repository.SaveChangesAsync()
         ? Ok("User updated successfully")
         : BadRequest("Erro while updating user");
        
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
       var Dbuser = await _repository.GetUserById(id);
       if(Dbuser == null)
            return BadRequest("User not found");
        
        _repository.DeleteUser(Dbuser);

        return await _repository.SaveChangesAsync()
            ? Ok("User successfully removed")
            : BadRequest("Erro while deleting user");
    }
}