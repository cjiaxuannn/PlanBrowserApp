using Microsoft.AspNetCore.Mvc;
using PlanBrowserAPI.Models;
using PlanBrowserAPI.Filters;
using PlanBrowserAPI.Services;

namespace PlanBrowserAPI.Controllers
{
    [ApiController]
    [Route("plans")]
    public class PlansController : ControllerBase
    {
        private readonly IPlanService _service;

        public PlansController(IPlanService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Plan>>> GetPlans([FromQuery] PlanQueryParameters query)
        {
            var plans = await _service.GetPlansAsync(query);
            return Ok(plans);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Plan>> GetPlan(int id)
        {
            var plan = await _service.GetPlanByIdAsync(id);
            return plan == null ? NotFound() : Ok(plan);
        }
    }
}
