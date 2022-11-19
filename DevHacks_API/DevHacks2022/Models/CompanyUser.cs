using System;
using System.Collections.Generic;

namespace DevHacks2022.Models;

public partial class CompanyUser
{
    public int Id { get; set; }

    public int IdUser { get; set; }

    public int IdCompany { get; set; }

    public bool Activ { get; set; }

}
