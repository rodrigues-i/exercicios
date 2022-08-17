using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudClientes.Models;

public class User
{
    // o id deveria ser uma string
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid id {get; set;}
    [Required]
    public string firstName {get; set;}
    public string? surname {get; set;}
    public int age {get; set; }

    public DateTime creationDate { get; set; }

}