using System;
using System.Collections.Generic;

namespace BooleanşMvcApp.Tables;

public partial class Subject
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? HoursOfLesson { get; set; }

    public virtual ICollection<ExamineResult> ExamineResults { get; set; } = new List<ExamineResult>();

    public virtual ICollection<Group> Groups { get; set; } = new List<Group>();
}
