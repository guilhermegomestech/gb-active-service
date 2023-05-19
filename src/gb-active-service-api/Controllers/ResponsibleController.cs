using gb_active_service_api.Controllers;
using gb_active_service_api.Interfaces.Notifications;
using gb_active_service_api.Interfaces.Services;
using gb_active_service_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace gb_responsible_service_api.Controllers
{
    [Route("api/v1/responsibles")]
    [ApiController]
    public class ResponsiblesController : MainController
    {
        private readonly IResponsibleService _responsibleService;

        public ResponsiblesController(INotificator notificator, IResponsibleService responsibleService) : base(notificator)
        {
            _responsibleService = responsibleService ?? throw new ArgumentNullException(nameof(responsibleService));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Responsible>>> GetResponsibles()
        {
            var responsibles = await _responsibleService.GetAll();
            return CustomResponse(responsibles);
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<Responsible>> GetResponsible(Guid id)
        {
            var responsible = await _responsibleService.GetById(id);
            if (responsible == null) return NotFound();

            return CustomResponse(responsible);
        }

        [HttpPost]
        public async Task<ActionResult<Responsible>> PostResponsible([FromBody] Responsible responsible)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _responsibleService.Create(responsible);

            return CustomResponse(responsible);
        }

        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> PutResponsible(Guid id, [FromBody] Responsible responsible)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            if (id != responsible.Id)
            {
                NotifyError("O Id informado é diferente do Id do objeto.");
                return CustomResponse(responsible);
            }

            await _responsibleService.Update(responsible);

            return CustomResponse(responsible);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> DeleteResponsible(Guid id)
        {
            var responsible = await _responsibleService.GetById(id);
            if (responsible == null) return NotFound();

            await _responsibleService.Delete(id);

            return CustomResponse();
        }
    }
}
