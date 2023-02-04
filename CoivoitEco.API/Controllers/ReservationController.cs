using CovoitEco.Core.Application.Models;
using CovoitEco.Core.Application.Services.Reservation.Commands;
using CovoitEco.Core.Application.Services.Reservation.Queries;
using CovoitEco.Core.Application.Services.VehiculeProfile.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoivoitEco.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ApiController
    {
        private readonly ILogger<ReservationController> _logger = null;
        public ReservationController(ILogger<ReservationController> logger)
        {
            _logger = logger;
        }

        [HttpGet("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ReservationProfileVm>> GetAllReservationProfile(int id)
        {
            try
            {
                _logger.LogInformation("GetAllReservationProfile");
                return await Mediator.Send(new GetAllReservationProfileQuery() {ANN_Id = id});
            }
            catch (Exception e)
            {
                _logger.LogError("Request GetAllReservationProfile fail");
                throw;
            }
        }

        [Authorize("read:messages")]
        [HttpGet("[action]"), Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ReservationUserProfileVm>> GetAllReservationUserProfile(int id)
        {
            try
            {
                _logger.LogInformation("GetAllReservationUserProfile");
                return await Mediator.Send(new GetAllReservationUserProfileQuery() { UTL_Id = id });
            }
            catch (Exception e)
            {
                _logger.LogError("Request GetAllReservationUserProfile fail");
                throw;
            }
        }

        [Authorize("read:messages")]
        [HttpGet("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ReservationUserProfileVm>> GetReservationUserProfile(int id)
        {
            try
            {
                _logger.LogInformation("GetReservationUserProfile");
                return await Mediator.Send(new GetReservationUserProfileQuery() { RES_Id = id });
            }
            catch (Exception e)
            {
                _logger.LogError("Request GetReservationUserProfile fail");
                throw;
            }
        }

        [Authorize("read:messages")]
        [HttpGet("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<int>> GetIdReservationUserProfile(int idAnn, int idUser)
        {
            try
            {
                _logger.LogInformation("GetAllReservationUserProfile");
                return await Mediator.Send(new GetIdReservationUserProfileQuery() { ANN_Id = idAnn, UTL_Id = idUser });
            }
            catch (Exception e)
            {
                _logger.LogError("Request GetIdReservationUserProfile fail");
                throw;
            }
        }

        [Authorize("write:messages")]
        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<int>> CreateReservation(CreateReservationCommand command)
        {
            try
            {
                _logger.LogInformation("CreateReservation");
                return await Mediator.Send(command); 
            }
            catch (Exception e)
            {
                _logger.LogError("Request CreateReservation fail");
                throw;
            }
        }

        [Authorize("write:messages")]
        [HttpPut("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<int>> UpdateAccepterReservation(int id)
        {
            try
            {
                _logger.LogInformation("UpdateAccepterReservation");
                return await Mediator.Send(new UpdateAccepterReservationCommand() {RES_Id = id});
            }
            catch (Exception e)
            {
                _logger.LogError("Request UpdateAccepterReservation fail");
                throw;
            }
        }

        [Authorize("write:messages")]
        [HttpPut("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<int>> UpdateConfirmePayment(int id)
        {
            try
            {
                _logger.LogInformation("UpdateConfirmePayment");
                return await Mediator.Send(new UpdateConfirmePaymentCommand() { RES_Id = id });
            }
            catch (Exception e)
            {
                _logger.LogError("Request UpdateConfirmePayment fail");
                throw;
            }
        }

        [Authorize("write:messages")]
        [HttpPut("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<int>> UpdateStatutReservation(int id)
        {
            try
            {
                _logger.LogInformation("UpdateStatutReservation");
                return await Mediator.Send(new UpdateStatutReservationCommand() {RES_Id = id});
            }
            catch (Exception e)
            {
                _logger.LogError("Request UpdateStatutReservation fail");
                throw;
            }
        }
    }
}
