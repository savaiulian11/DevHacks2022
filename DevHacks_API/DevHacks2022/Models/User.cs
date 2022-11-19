using System;
using System.Collections.Generic;

namespace DevHacks2022.Models;

public partial class User
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Number { get; set; } = null!;

}
