using System;
using System.Collections.Generic;

namespace BooleanşMvcApp.Tables;

public partial class StudentDetail
{
    public int Id { get; set; }

    public string? BirthPlace { get; set; }

    public int? AcceptPoint { get; set; }

    public int? StudentId { get; set; }

    public virtual Student? Student { get; set; }
}
