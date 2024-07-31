using System;
using System.Collections.Generic;

namespace BooleanşMvcApp.Tables;

public partial class ExamineResult
{
    public int Id { get; set; }

    public DateTime? ExamDate { get; set; }

    public int? Result { get; set; }

    public int? StudentId { get; set; }

    public int? SubjectId { get; set; }

    public virtual Student? Student { get; set; }

    public virtual Subject? Subject { get; set; }
}
