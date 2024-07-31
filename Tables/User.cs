using System;
using System.Collections.Generic;

namespace BooleanşMvcApp.Tables;

public partial class User
{
    public int Id { get; set; }

    public string? Email { get; set; }

    public int? Age { get; set; }

    public string? Password { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public string WebSiteUrl { get; set; } = null!;
}
