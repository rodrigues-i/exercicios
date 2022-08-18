using Clients.API.Models;
using Microsoft.AspNetCore.Mvc;
using Clients.API.Repository;

namespace Clients.API.Controllers;

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
    public async Task<ActionResult> GetAll()
    {
        var users = await _repository.GetUsers();
        if(!users.Any())
            return NotFound();
            
        return Ok(users);
    }
        

    [HttpGet("{id}")]
    public async Task<ActionResult> Get(Guid id)
    {
        var Dbuser = await _repository.GetUserById(id);
        if(Dbuser == null)
            return NotFound("User not found");
        
        return Ok(Dbuser);
    }

    [HttpPost]
    public async Task<IActionResult> Create(User user)
    {
        if(user.age == 0)
            return BadRequest("Attribute age is required");
        else if(user.firstName == null || user.firstName.Trim() == "")
            return BadRequest("Attribute firstName is required");

        user.firstName = user.firstName.Trim();
        if(user.surname != null)
            user.surname = user.surname.Trim();
        
        user.creationDate = DateTime.Now;
        _repository.AddUser(user);
        
        return await _repository.SaveChangesAsync()
        ? Ok("User created successfully")
        : BadRequest("Error while trying to add new user");
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<User>> Update(Guid id, User user)
    {
        if(user.age == 0)
            return BadRequest("Attribute age is required");
        else if(user.firstName == null || user.firstName.Trim() == "")
            return BadRequest("Attribute firstName is required");

        var Dbuser = await _repository.GetUserById(id);
        if(Dbuser == null)
            return BadRequest("User not found");

        user.firstName = user.firstName.Trim();
        if(user.surname != null)
            user.surname = user.surname.Trim();
        
        Dbuser.firstName = user.firstName ?? Dbuser.firstName;
        Dbuser.surname = user.surname ?? Dbuser.surname;
        Dbuser.age = user.age == 0 ? Dbuser.age : user.age;

         _repository.UpdateUser(Dbuser);

         return await _repository.SaveChangesAsync()
         ? Ok("User updated successfully")
         : BadRequest("Erro while updating user");
        
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
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