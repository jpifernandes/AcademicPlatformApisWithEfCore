using AcademicPlatformApisWithEfCore.Domain.DTOs.Request;
using AcademicPlatformApisWithEfCore.Domain.DTOs.Response;
using AcademicPlatformApisWithEfCore.Domain.Entities;
using AcademicPlatformApisWithEfCore.Domain.Interfaces.Mappers;
using AcademicPlatformApisWithEfCore.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademicPlatformApisWithEfCore.Controllers
{
    [Route("api/users/v1")]
    [ApiController]
    [ProducesResponseType(typeof(ProblemDetails), 500)]
    public class UsersController : ControllerBase
    {
        private readonly IUserServices _services;
        private readonly IObjectConverter _objConverter;
        
        public UsersController(IUserServices services, IObjectConverter objConverter)
        {
            _services = services ?? throw new ArgumentNullException(nameof(services));
            _objConverter = objConverter ?? throw new ArgumentNullException(nameof(objConverter));
        }

        [HttpPost]
        [ProducesResponseType(200)]     
        public async Task<ActionResult> Post([FromBody] UserCreationRequestDto userDto)
        {
            User user = _objConverter.Map<User>(userDto);

            await _services.AddOne(user).ConfigureAwait(false);

            return Ok();
        }

        [HttpPost("add-many")]
        [ProducesResponseType(200)]
        public async Task<ActionResult> Post([FromBody] IEnumerable<UserCreationRequestDto> usersDto)
        {
            IEnumerable<User> users = _objConverter.Map<IEnumerable<User>>(usersDto);

            await _services.AddMany(users).ConfigureAwait(false);

            return Ok();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UserResponseDto), 200)]
        public async Task<ActionResult<UserResponseDto>> Get([FromRoute] int id)
        {
            User user = await _services.ReadById(id).ConfigureAwait(false);

            if (user == null)
                return NotFound();

            UserResponseDto response = _objConverter.Map<UserResponseDto>(user);

            return Ok(response);
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<UserResponseDto>), 200)]
        public async Task<ActionResult<IEnumerable<UserResponseDto>>> Get()
        {
            IEnumerable<User> users = await _services.ReadAll().ConfigureAwait(false);

            if (users == null || !users.Any())
                return Ok(Array.Empty<UserResponseDto>());

            IEnumerable<UserResponseDto> response = _objConverter.Map<IEnumerable<UserResponseDto>>(users);

            return Ok(response);
        }

        [HttpPut]
        [ProducesResponseType(200)]
        public async Task<ActionResult> Put([FromBody] User user)
        {
            await _services.UpdateOne(user).ConfigureAwait(false);
            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            await _services.DeleteById(id).ConfigureAwait(false);
            return Ok();
        }
    }
}
