using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models;

public class Project
{
    public int Id { get; set; }
    public string? ProjectName { get; set; }
    [DataType(DataType.Date)]
    public DateTime LastUpdated { get; set; }
    public string? Language { get; set; }
}