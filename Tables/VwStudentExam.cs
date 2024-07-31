using System;
using System.Collections.Generic;

namespace BooleanşMvcApp.Tables;

public partial class VwStudentExam
{
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public int? Result { get; set; }

    public string? Name { get; set; }

    public string ResultName { get; set; } = null!;
}
