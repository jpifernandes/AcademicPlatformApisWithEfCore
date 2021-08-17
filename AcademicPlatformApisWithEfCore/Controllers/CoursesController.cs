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
    [Route("api/courses/v1")]
    [ApiController]
    [ProducesResponseType(typeof(ProblemDetails), 500)]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseServices _services;
        private readonly IObjectConverter _objConverter;

        public CoursesController(ICourseServices services, IObjectConverter objConverter)
        {
            _services = services ?? throw new ArgumentNullException(nameof(services));
            _objConverter = objConverter ?? throw new ArgumentNullException(nameof(objConverter));
        }

        [HttpPost]
        [ProducesResponseType(200)]
        public async Task<ActionResult> Post([FromBody] CourseCreationRequestDto courseDto)
        {
            Course course = _objConverter.Map<Course>(courseDto);

            await _services.AddOne(course).ConfigureAwait(false);

            return Ok();
        }

        [HttpPost("add-many")]
        [ProducesResponseType(200)]
        public async Task<ActionResult> Post([FromBody] IEnumerable<CourseCreationRequestDto> coursesDto)
        {
            IEnumerable<Course> courses = _objConverter.Map<IEnumerable<Course>>(coursesDto);

            await _services.AddMany(courses).ConfigureAwait(false);

            return Ok();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CourseResponseDto), 200)]
        public async Task<ActionResult<CourseResponseDto>> Get([FromRoute] int id)
        {
            Course course = await _services.ReadById(id).ConfigureAwait(false);

            if (course == null)
                return NotFound();

            CourseResponseDto response = _objConverter.Map<CourseResponseDto>(course);

            return Ok(response);
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CourseResponseDto>), 200)]
        public async Task<ActionResult<IEnumerable<CourseResponseDto>>> Get()
        {
            IEnumerable<Course> courses = await _services.ReadAll().ConfigureAwait(false);

            if (courses == null || !courses.Any())
                return Ok(Array.Empty<CourseResponseDto>());

            IEnumerable<CourseResponseDto> response = _objConverter.Map<IEnumerable<CourseResponseDto>>(courses);

            return Ok(response);
        }

        [HttpPut]
        [ProducesResponseType(200)]
        public async Task<ActionResult> Put([FromBody] Course course)
        {
            await _services.UpdateOne(course).ConfigureAwait(false);
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
