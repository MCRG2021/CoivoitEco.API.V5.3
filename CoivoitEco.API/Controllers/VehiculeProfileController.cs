using CovoitEco.Core.Application.Services.VehiculeProfile.Commands;
using CovoitEco.Core.Application.Services.VehiculeProfile.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoivoitEco.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculeProfileController : ApiController
    {
        private readonly ILogger<VehiculeProfileController> _logger = null;
        public VehiculeProfileController(ILogger<VehiculeProfileController> logger)
        {
            _logger = logger;
        }

        [HttpGet("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<VehiculeProfileVm>> GetVehiculeProfile(int id)
        {
            try
            {
                _logger.LogInformation("GetVehiculeProfile");
                return await Mediator.Send(new GetVehiculeProfileQuery() {UTL_Id = id});
            }
            catch (Exception e)
            {
                _logger.LogError("Request GetVehiculeProfile fail");
                throw;
            }
        }

        [HttpGet("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<VehiculeProfileVm>> GetVehicule(int id)
        {
            try
            {
                _logger.LogInformation("GetVehiculeProfile");
                return await Mediator.Send(new GetVehiculeQuery() { ANN_Id = id });
            }
            catch (Exception e)
            {
                _logger.LogError("Request GetVehiculeProfile fail");
                throw;
            }
        }

        [HttpGet("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<VehiculeProfileVm>> GetAllVehiculeProfile(int id)
        {
            try
            {
                _logger.LogInformation("GetAllVehiculeProfile");
                return await Mediator.Send(new GetAllVehiculeProfileQuery() {UTL_Id = id});
            }
            catch (Exception e)
            {
                _logger.LogError("Request GetAllVehiculeProfile fail");
                throw;
            }
        }

        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<int>> CreateVehiculeProfile(CreateVehiculeProfileCommand command)
        {
            try
            {
                _logger.LogInformation("CreateVehiculeProfile");
                return await Mediator.Send(command); 
            }
            catch (Exception e)
            {
                _logger.LogError("Request CreateVehiculeProfile fail");
                throw;
            }
        }

        [HttpPut("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<int>> UpdateVehiculeProfile(UpdateVehiculeProfileCommand command)
        {
            try
            {
                _logger.LogInformation("UpdateVehiculeProfile");
                return await Mediator.Send(command);
            }
            catch (Exception e)
            {
                _logger.LogError("Request UpdateVehiculeProfile fail");
                throw;
            }
        }
        /// <summary>
        /// Ohters solution
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //public async Task<ActionResult<int>> UpdateVehiculeProfile(int id, bool dispo,bool courant)
        //{
        //    try
        //    {
        //        _logger.LogInformation("VehiculeProfile");
        //        return await Mediator.Send(new UpdateVehiculeProfileCommand() {VEH_Id = id, VEH_Courant = courant, VEH_Disponible = dispo});
        //    }
        //    catch (Exception e)
        //    {
        //        _logger.LogError("Request VehiculeProfile fail");
        //        throw;
        //    }
        //}

        [HttpDelete("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteVehiculeProfile(int id)
        {
            try
            {
                _logger.LogInformation("DeleteVehiculeProfile");
                await Mediator.Send(new DeleteVehiculeProfileCommand() { VEH_Id = id});
            }
            catch (Exception e)
            {
                _logger.LogError("Request DeleteVehiculeProfile fail");
                throw;
            }

            return NoContent();
        }
    }
}
