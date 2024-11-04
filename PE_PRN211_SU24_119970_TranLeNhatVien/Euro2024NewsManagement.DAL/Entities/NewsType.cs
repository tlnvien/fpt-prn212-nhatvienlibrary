using System;
using System.Collections.Generic;

namespace Euro2024NewsManagement.DAL.Entities;

public partial class NewsType
{
    public string NewsTypeId { get; set; } = null!;

    public string TypeName { get; set; } = null!;

    public string TypeDescription { get; set; } = null!;

    public virtual ICollection<FootballNews> FootballNews { get; set; } = new List<FootballNews>();
}
