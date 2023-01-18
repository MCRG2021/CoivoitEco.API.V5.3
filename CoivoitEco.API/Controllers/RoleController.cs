using CovoitEco.API.Consume.Auth0.Interface.Role.Commands;
using CovoitEco.API.Consume.Auth0.Interface.Role.Queries;
using CovoitEco.API.Consume.Auth0.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoivoitEco.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ApiController
    {
       
        private readonly IQueriesRoleService _queriesRoleService; 
        private readonly ICommandsRoleService _commandsRoleService;
        private readonly ILogger<RoleController> _logger = null;

        public RoleController(IQueriesRoleService queriesRoleService, ICommandsRoleService commandsRoleService, ILogger<RoleController> logger)
        {
            _queriesRoleService = queriesRoleService;
            _commandsRoleService = commandsRoleService;
            _logger = logger;
        }

        //[Authorize("read:users")] 
        [HttpGet("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllRoles()
        {
            List<Role> ?result = null;
            try
            {
                _logger.LogInformation("GetAllRoles");
               result = await _queriesRoleService.GetAllAsync();
            }
            catch (Exception e)
            {
                _logger.LogError("Request GetAllRoles fail");
                throw;
            }
            return Ok(result);
        }

        //[Authorize("write:users")] 
        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AssignRole(UserRole userRole, string idRole)
        {
            try
            {
                _logger.LogInformation("AssignRole");
                await _commandsRoleService.AssignRole(userRole, idRole);
            }
            catch (Exception e)
            {
                _logger.LogError("Request AssignRole fail");
                throw;
            }
            return Ok();
        }

        //[Authorize("write:users")] 
        [HttpDelete("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RemoveRole(RemoveRoleUser userRole, string idUser)
        {
            try
            {
                _logger.LogInformation("RemoveRole");
                await _commandsRoleService.RemoveRole(userRole, idUser);
            }
            catch (Exception e)
            {
                _logger.LogError("Request AssRemoveRole fail");
                throw;
            }
            return Ok();
        }
    }
}
