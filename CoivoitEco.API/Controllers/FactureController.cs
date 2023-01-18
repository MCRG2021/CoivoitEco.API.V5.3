using CovoitEco.Core.Application.Services.Facture.Commands;
using CovoitEco.Core.Application.Services.Facture.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoivoitEco.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FactureController : ApiController
    {
        private readonly ILogger<FactureController> _logger = null;
        public FactureController(ILogger<FactureController> logger)
        {
            _logger = logger;
        }

        [HttpGet("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<int>> GetIdFactureReservation(int id)
        {
            try
            {
                _logger.LogInformation("GetIdFactureReservation");
                return await Mediator.Send(new GetIdFactureReservationQuery() { RES_Id = id });
            }
            catch (Exception e)
            {
                _logger.LogError("Request GetIdFactureReservation fail");
                throw;
            }
        }

        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<int>> CreateFacture(int id)
        {
            try
            {
                _logger.LogInformation("CreateFacture");
                return await Mediator.Send(new CreateFactureCommand() {FACT_RES_Id = id}); ;
            }
            catch (Exception e)
            {
                _logger.LogError("Request CreateFacture fail");
                throw;
            }
        }

        [HttpPut("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<int>> UpdateFacturePayment(int id)
        {
            try
            {
                _logger.LogInformation("UpdateFacturePayment");
                return await Mediator.Send(new UpdateFacturePaymentCommand() {FACT_Id = id});
            }
            catch (Exception e)
            {
                _logger.LogError("Request UpdateFacturePayment fail");
                throw;
            }
        }
    }
}
