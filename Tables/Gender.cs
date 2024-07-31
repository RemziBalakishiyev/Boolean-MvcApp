using System;
using System.Collections.Generic;

namespace BooleanşMvcApp.Tables;

public partial class Gender
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
