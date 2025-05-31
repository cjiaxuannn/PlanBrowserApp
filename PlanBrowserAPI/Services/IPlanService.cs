using PlanBrowserAPI.Models;
using PlanBrowserAPI.Filters;

namespace PlanBrowserAPI.Services
{
    public interface IPlanService
    {
        Task<IEnumerable<Plan>> GetPlansAsync(PlanQueryParameters query);
        Task<Plan?> GetPlanByIdAsync(int id);
    }
}