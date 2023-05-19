using gb_active_service_api.Controllers;
using gb_active_service_api.Interfaces.Notifications;
using gb_active_service_api.Interfaces.Services;
using gb_active_service_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace gb_dependency_service_api.Controllers
{
    [Route("api/v1/dependencies")]
    [ApiController]
    public class DependenciesController : MainController
    {
        private readonly IDependencyService _dependencyService;

        public DependenciesController(INotificator notificator, IDependencyService dependencyService) : base(notificator)
        {
            _dependencyService = dependencyService ?? throw new ArgumentNullException(nameof(dependencyService));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dependency>>> GetDependencies()
        {
            var dependencies = await _dependencyService.GetAll();
            return CustomResponse(dependencies);
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<Dependency>> GetDependency(Guid id)
        {
            var dependency = await _dependencyService.GetById(id);
            if (dependency == null) return NotFound();

            return CustomResponse(dependency);
        }

        [HttpPost]
        public async Task<ActionResult<Dependency>> PostDependency([FromBody] Dependency dependency)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _dependencyService.Create(dependency);

            return CustomResponse(dependency);
        }

        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> PutDependency(Guid id, [FromBody] Dependency dependency)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            if (id != dependency.Id)
            {
                NotifyError("O Id informado é diferente do Id do objeto.");
                return CustomResponse(dependency);
            }

            await _dependencyService.Update(dependency);

            return CustomResponse(dependency);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> DeleteDependency(Guid id)
        {
            var dependency = await _dependencyService.GetById(id);
            if (dependency == null) return NotFound();

            await _dependencyService.Delete(id);

            return CustomResponse();
        }
    }
}
