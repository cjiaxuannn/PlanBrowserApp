namespace PlanBrowserAPI.Models;

public class Plan
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string DataLimit { get; set; } = string.Empty;
    public int ValidityDays { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; } = string.Empty;
}