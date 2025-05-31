namespace PlanBrowserAPI.Filters
{
    public class PlanQueryParameters
    {
        public string? Type { get; set; }
        public string? Name { get; set; }
        public string? DataLimit { get; set; }
        public int? ValidityDays { get; set; }
        public decimal? Price { get; set; }
    }
}
