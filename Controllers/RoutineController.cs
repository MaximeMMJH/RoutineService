using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RoutineService.Logic;
using RoutineService.Mappers;
using RoutineService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace RoutineService.Controllers
{
    [ApiController]
    [Route("/routines")]
    public class RoutineController : Controller
    {
        private readonly ILogger<RoutineController> logger;
        private RoutineFacade routineFacade;

        public RoutineController(ILogger<RoutineController> logger, RoutineFacade routineFacade)
        {
            this.logger = logger;
            this.routineFacade = routineFacade;
        }

        [HttpGet]
        [Route("/routines/users/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(RoutineQM[]), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public IActionResult GetUserRoutines([FromRoute] Guid id, [FromQuery] int pageNumber, [FromQuery] int pageSize)
        {
            logger.LogInformation("The retrieval of a list of routinea has been requested");

            if (!ModelState.IsValid) return BadRequest();

            try
            {
                return Ok(
                    RoutineMapper.MapToRoutinePageResponse(
                        routineFacade.GetUserRoutines(id, pageNumber, pageSize)));
            } catch (Exception e)
            {
                logger.LogError("error occured when retrieving a list of routines", e);
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPatch]
        [Route("/routines/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public IActionResult CountCompletion([FromRoute] Guid id)
        {
            logger.LogInformation("Count routine completion");

            if (!ModelState.IsValid) return BadRequest();

            try
            {
                routineFacade.CountCompletion(id);
                return NoContent();
            }
            catch (Exception e)
            {
                logger.LogError("error occured when counting a routine completion", e);
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet]
        [Route("/routines/{id}")]
        [ProducesResponseType(typeof(RoutineQM), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public IActionResult GetRoutine([FromRoute] Guid id)
        {
            logger.LogInformation("The retrieval of a routine has been requested");

            if (!ModelState.IsValid) return BadRequest();

            try
            {
                return Ok(
                    RoutineMapper.MapToRoutineQM(routineFacade.GetRoutine(id)));
            }
            catch (Exception e)
            {
                logger.LogError("error occured when retrieving an routine", e);
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(RoutineQM), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public IActionResult CreateRoutine([FromBody] RoutineQM routine)
        {
            logger.LogInformation("The creation of a routine is requested");

            if (!ModelState.IsValid) return BadRequest();

            try
            {
                return Ok(
                    RoutineMapper.MapToRoutineQM(
                        routineFacade.CreateRoutine(
                            RoutineMapper.MapToRoutineDTO(routine))));
            }
            catch (Exception e)
            {
                logger.LogError("error occured when creating an exercise", e);
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpDelete]
        [Route("/routines/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public IActionResult deleteRoutine([FromRoute] Guid id)
        {
            logger.LogInformation("The deletion of a routine is requested");

            try
            {
                routineFacade.DeleteRoutine(id);
                return NoContent();
            }
            catch (Exception e)
            {
                logger.LogError("error occured when deleting a routine", e);
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPut]
        [Route("/routines/{id}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(RoutineQM), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateRoutine([FromRoute] Guid id, [FromBody] RoutineQM routine)
        {
            logger.LogInformation("The update of a routine is requested");

            if (!ModelState.IsValid) return BadRequest();

            try
            {
                return Ok(
                    RoutineMapper.MapToRoutineQM(
                        routineFacade.UpdateRoutine(
                            id, RoutineMapper.MapToRoutineDTO(routine))));

            }
            catch (Exception e)
            {
                logger.LogError("error occured when updating a routine", e);
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
