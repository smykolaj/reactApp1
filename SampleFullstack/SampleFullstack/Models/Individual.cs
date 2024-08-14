using System.ComponentModel.DataAnnotations;
using Project.Services.Interfaces;

namespace Project.Models;

public class Individual : ISoftDelete
{
    [Key]
    public long IdIndividual { get; set; }

    [Required] [MaxLength(100)] [MinLength(2)]
    public string FirstName { get; set; }= string.Empty;

    [Required] [MaxLength(100)] [MinLength(2)]
    public string LastName { get; set; }= string.Empty;

    [Required] [MaxLength(100)] [MinLength(5)]
    public string Address { get; set; }= string.Empty;

    [Required] [MaxLength(100)] [EmailAddress]
    public string Email { get; set; }= string.Empty;

    [Required] [MaxLength(12)] [Phone]
    public string PhoneNumber { get; set; }= string.Empty;
    
    [Required] [MaxLength(11)] [MinLength(11)]
    public string Pesel { get; set; }= string.Empty;

    public bool IsDeleted { get; set; } = false;

    public ICollection<Contract> Contracts { get; set; } = new HashSet<Contract>();
}