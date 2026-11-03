using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models;

public class Project
{
    [Key]
    public string ID { get; set; } = string.Empty;

    [Required]
    [Display(Name = "Project Name")]
    public string Name { get; set; } = string.Empty;

    [Display(Name = "GitHub URL")]
    public string? HTML_URL { get; set; }

    public string? Language { get; set; }
}