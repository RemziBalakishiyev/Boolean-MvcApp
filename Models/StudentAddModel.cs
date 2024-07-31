using DataAnnotationsExtensions;
using System.ComponentModel.DataAnnotations;

namespace BooleanşMvcApp.Models;

public class StudentAddModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "First Name is required")]
    public string FirstName { get; set; } = null!;
    [Required(ErrorMessage = "Last Name is required")]
    public string LastName { get; set; } = null!;

    public string? Patronymic { get; set; }
    [Required(ErrorMessage = "Group is required")]
    public int? GroupId { get; set; }
    [Required(ErrorMessage = "Group is required")]
    public int? GenderId { get; set; }

    public string? BirthPlace { get; set; }
    public DateOnly? DateOfBirth { get; set; }
    [Required(ErrorMessage = "Accept point is required")]
    [Min(30, ErrorMessage ="Accept point must be between 30 and 100")]
    [Max(100, ErrorMessage = "Accept point must be between 30 and 100")]
    public int? AcceptPoint { get; set; }
}
