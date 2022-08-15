using System.ComponentModel.DataAnnotations;

namespace CrudClientes.Models;

public class User
{
    // o id deveria ser uma string
    public int id {get; set;}
    [Required]
    public string firstName {get; set;}
    public string? surname {get; set;}
    public int age {get; set; }

    public DateTime creationDate { get; set; }

}