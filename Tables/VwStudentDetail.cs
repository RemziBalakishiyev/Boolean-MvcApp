using System;
using System.Collections.Generic;

namespace BooleanşMvcApp.Tables;

public partial class VwStudentDetail
{
    public string FullName { get; set; } = null!;

    public int? AcceptPoint { get; set; }

    public string GroupName { get; set; } = null!;

    public int? Result { get; set; }

    public string? SubjectName { get; set; }
}
