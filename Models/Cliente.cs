namespace CrudClientes.Models;

public class Cliente
{
    // o id deveria ser uma string
    public int id {get; set;}
    public string? firstName {get; set;}
    public string? surname {get; set;}
    public int age {get; set; }

}