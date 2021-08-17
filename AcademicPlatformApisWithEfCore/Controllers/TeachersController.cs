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
    [Route("api/teachers/v1")]
    [ApiController]
    [ProducesResponseType(typeof(ProblemDetails), 500)]
    public class TeachersController : ControllerBase
    {
        private readonly ITeacherServices _services;
        private readonly IObjectConverter _objConverter;

        public TeachersController(ITeacherServices services, IObjectConverter objConverter)
        {
            _services = services ?? throw new ArgumentNullException(nameof(services));
            _objConverter = objConverter ?? throw new ArgumentNullException(nameof(objConverter));
        }

        [HttpPost]
        [ProducesResponseType(200)]
        public async Task<ActionResult> Post([FromBody] TeacherCreationRequestDto teacherDto)
        {
            Teacher teacher = _objConverter.Map<Teacher>(teacherDto);

            await _services.AddOne(teacher).ConfigureAwait(false);

            return Ok();
        }

        [HttpPost("add-many")]
        [ProducesResponseType(200)]
        public async Task<ActionResult> Post([FromBody] IEnumerable<TeacherCreationRequestDto> teachersDto)
        {
            IEnumerable<Teacher> teachers = _objConverter.Map<IEnumerable<Teacher>>(teachersDto);

            await _services.AddMany(teachers).ConfigureAwait(false);

            return Ok();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(TeacherResponseDto), 200)]
        public async Task<ActionResult<TeacherResponseDto>> Get([FromRoute] int id)
        {
            Teacher teacher = await _services.ReadById(id).ConfigureAwait(false);

            if (teacher == null)
                return NotFound();

            TeacherResponseDto response = _objConverter.Map<TeacherResponseDto>(teacher);

            return Ok(response);
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<TeacherResponseDto>), 200)]
        public async Task<ActionResult<IEnumerable<TeacherResponseDto>>> Get()
        {
            IEnumerable<Teacher> teachers = await _services.ReadAll().ConfigureAwait(false);

            if (teachers == null || !teachers.Any())
                return Ok(Array.Empty<TeacherResponseDto>());

            IEnumerable<TeacherResponseDto> response = _objConverter.Map<IEnumerable<TeacherResponseDto>>(teachers);

            return Ok(response);
        }

        [HttpPut]
        [ProducesResponseType(200)]
        public async Task<ActionResult> Put([FromBody] Teacher teacher)
        {
            await _services.UpdateOne(teacher).ConfigureAwait(false);
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
