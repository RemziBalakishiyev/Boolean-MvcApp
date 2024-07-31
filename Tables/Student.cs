using System;
using System.Collections.Generic;

namespace BooleanşMvcApp.Tables;

public partial class Student
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Patronymic { get; set; }

    public int? GroupId { get; set; }

    public int? GenderId { get; set; }

    public DateOnly? DateOfBirth { get; set; }

    public virtual ICollection<ExamineResult> ExamineResults { get; set; } = new List<ExamineResult>();

    public virtual Gender? Gender { get; set; }
    public virtual Group? Group { get; set; }

    public virtual StudentDetail? StudentDetail { get; set; }
}
