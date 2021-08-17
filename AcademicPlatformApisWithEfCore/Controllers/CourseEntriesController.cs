using AcademicPlatformApisWithEfCore.Domain.DTOs.Request;
using AcademicPlatformApisWithEfCore.Domain.DTOs.Response;
using AcademicPlatformApisWithEfCore.Domain.Entities;
using AcademicPlatformApisWithEfCore.Domain.Filters;
using AcademicPlatformApisWithEfCore.Domain.Interfaces.Mappers;
using AcademicPlatformApisWithEfCore.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademicPlatformApisWithEfCore.Controllers
{
    [Route("api/course-entries/v1")]
    [ApiController]
    [ProducesResponseType(typeof(ProblemDetails), 500)]
    public class CourseEntriesController : ControllerBase
    {
        private readonly ICourseEntryServices _services;
        private readonly IObjectConverter _objConverter;

        public CourseEntriesController(ICourseEntryServices services, IObjectConverter objConverter)
        {
            _services = services ?? throw new ArgumentNullException(nameof(services));
            _objConverter = objConverter ?? throw new ArgumentNullException(nameof(objConverter));
        }

        [HttpPost]
        [ProducesResponseType(200)]
        public async Task<ActionResult> Post([FromBody] CourseEntryCreationRequestDto entryDto)
        {
            CourseEntry entry = _objConverter.Map<CourseEntry>(entryDto);

            await _services.AddOne(entry).ConfigureAwait(false);

            return Ok();
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CourseEntryResponseDto>), 200)]
        public async Task<ActionResult<IEnumerable<CourseEntryResponseDto>>> Get([FromQuery] CourseEntrySearchFilter filter)
        {
            IEnumerable<CourseEntry> courseEntries = null;

            if (filter.CourseId.HasValue)
                courseEntries = await _services.ReadByCourse(filter.CourseId.Value).ConfigureAwait(false);
            else if (filter.UserId.HasValue)
                courseEntries = await _services.ReadByUser(filter.UserId.Value).ConfigureAwait(false);
            else
                return BadRequest();

            if (courseEntries == null || !courseEntries.Any())
                return NotFound();

            IEnumerable<CourseEntryResponseDto> response = _objConverter.Map<IEnumerable<CourseEntryResponseDto>>(courseEntries);

            return Ok(response);
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
