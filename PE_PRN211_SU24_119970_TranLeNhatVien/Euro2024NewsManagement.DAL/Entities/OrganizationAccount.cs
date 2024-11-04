using System;
using System.Collections.Generic;

namespace Euro2024NewsManagement.DAL.Entities;

public partial class OrganizationAccount
{
    public int AccountId { get; set; }

    public string AccountPassword { get; set; } = null!;

    public string? OrganizationEmail { get; set; }

    public string ShortDescription { get; set; } = null!;

    public int? Role { get; set; }
}
