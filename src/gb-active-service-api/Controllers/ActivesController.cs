using gb_active_service_api.Interfaces.Notifications;
using gb_active_service_api.Interfaces.Services;
using gb_active_service_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace gb_active_service_api.Controllers
{
    [Route("api/v1/actives")]
    [ApiController]
    public class ActivesController : MainController
    {
        private readonly IActiveService _activeService;

        public ActivesController(INotificator notificator, IActiveService activeService) : base(notificator)
        {
            _activeService = activeService ?? throw new ArgumentNullException(nameof(activeService));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Active>>> GetActives()
        {
            var actives = await _activeService.GetAll();
            return CustomResponse(actives);
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<Active>> GetActive(Guid id)
        {
            var active = await _activeService.GetById(id);
            if (active == null) return NotFound();

            return CustomResponse(active);
        }

        [HttpPost]
        public async Task<ActionResult<Active>> PostActive([FromBody] Active active)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _activeService.Create(active);

            return CustomResponse(active);
        }

        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> PutActive(Guid id, [FromBody] Active active)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            if (id != active.Id)
            {
                NotifyError("O Id informado é diferente do Id do objeto.");
                return CustomResponse(active);
            }

            await _activeService.Update(active);

            return CustomResponse(active);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> DeleteActive(Guid id)
        {
            var active = await _activeService.GetById(id);
            if (active == null) return NotFound();

            await _activeService.Delete(id);

            return CustomResponse();
        }
    }
}
