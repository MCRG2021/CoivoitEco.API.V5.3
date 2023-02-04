using CoivoitEco.API.Filter;
using CovoitEco.API.Consume.Auth0.Interface.User.Commands;
using CovoitEco.API.Consume.Auth0.Interface.User.Queries;
using CovoitEco.API.Consume.Auth0.Models;
using CovoitEco.Core.Application.Filter;
using CovoitEco.Core.Application.Services.Annonce.Queries;
using CovoitEco.Core.Application.Services.User.Commands;
using CovoitEco.Core.Application.Services.User.Queries;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoivoitEco.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ApiController
    {
        private readonly HttpClient _client; 
        private readonly ICommandsUserService _commandsUserService;
        private readonly IQueriesUserService _queriesUserService;
        private readonly ILogger<RoleController> _logger = null;

        public UserController(IQueriesUserService queriesUserService, ICommandsUserService commandsUserService, ILogger<RoleController> logger, HttpClient client)
        {
            _queriesUserService = queriesUserService;
            _commandsUserService = commandsUserService;
            _logger = logger;
            _client = client;
        }

        //Authorize not required
        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateUser(CreateUserCommand command)
        {
            try
            {
                _logger.LogInformation("CreateUser");
                await Mediator.Send(command);
            }
            catch (Exception e)
            {
                _logger.LogError("Request CreateUser fail");
                throw;
            }
            return Ok();
        }

        [Authorize("write:users")]
        [HttpPatch("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateUser(UserUpdate user, string idUser)
        {
            try
            {
                _logger.LogInformation("UpdateUser");
                await _commandsUserService.UpdateUser(user, idUser);
            }
            catch (Exception e)
            {
                _logger.LogError("Request UpdateUser fail");
                throw;
            }
            return Ok();
        }

        [Authorize("write:users")] 
        [HttpDelete("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteUser(string idUser)
        {
            try
            {
                _logger.LogInformation("DeleteUser");
                await _commandsUserService.DeleteUser(idUser);
            }
            catch (Exception e)
            {
                _logger.LogError("Request DeleteUser fail");
                throw;
            }
            return Ok();
        }

        [Authorize("read:users")] 
        [HttpGet("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllUsers(int pageSize, int pageNumber)
        {

            List<UserResponse> ?result = null;
            try
            {
                _logger.LogInformation("GetAllUsers");
                result = await _queriesUserService.GetAllAsync(pageSize,pageNumber);
            }
            catch (Exception e)
            {
                _logger.LogError("Request GetAllUsers fail");
                throw;
            }
            return Ok(result);
        }

        [Authorize("read:messages")] 
        [HttpGet("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUserInfo(string accessToken)
        {

            UserInfo result = null;
            try
            {
                _logger.LogInformation("GetAllUsers");
                result = await _queriesUserService.GetUserInfo(accessToken);
            }
            catch (Exception e)
            {
                _logger.LogError("Request GetAllUsers fail");
                throw;
            }
            return Ok(result);
        }

        [Authorize("read:messages")]
        [HttpGet("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UserProfileVm>> GetUserProfile(int id)
        {
            try
            {
                _logger.LogInformation("GetUserProfile");
                return await Mediator.Send(new GetUserProfileQuery() { UTL_Id = id});
            }
            catch (Exception e)
            {
                _logger.LogError("Request GetUserProfile fail");
                throw;
            }
        }

        [Authorize("read:messages")]
        [HttpGet("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<int> GetIdUserProfile(string mail)
        {
            try
            {
                _logger.LogInformation("GetIdUserProfile");
                return await Mediator.Send(new GetIdUserProfileQuery() { UTL_Mail = mail});
            }
            catch (Exception e)
            {
                _logger.LogError("Request GetIdUserProfile fail");
                throw;
            }
        }
    }
}
