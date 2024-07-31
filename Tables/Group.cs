using System;
using System.Collections.Generic;

namespace BooleanşMvcApp.Tables;

public partial class Group
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime? CreatedDate { get; set; }

    public virtual ICollection<Subject> Subjects { get; set; } = new List<Subject>();
}
