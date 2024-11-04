using System;
using System.Collections.Generic;

namespace Euro2024NewsManagement.DAL.Entities;

public partial class FootballNews
{
    public string FootballNewsId { get; set; } = null!;

    public string NewsTitle { get; set; } = null!;

    public string ShortDescription { get; set; } = null!;

    public DateTime? CreatedDate { get; set; }

    public string ManagerialChanges { get; set; } = null!;

    public string TacticalAnalysis { get; set; } = null!;

    public string MatchReports { get; set; } = null!;

    public string? NewsTypeId { get; set; }

    public virtual NewsType? NewsType { get; set; }
}
