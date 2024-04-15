using Microsoft.AspNetCore.Mvc;
using SimpleTaskManager.Application.UseCases.Task.Delete;
using SimpleTaskManager.Application.UseCases.Task.GetAll;
using SimpleTaskManager.Application.UseCases.Task.GetTask;
using SimpleTaskManager.Application.UseCases.Task.Register;
using SimpleTaskManager.Application.UseCases.Task.Update;
using SimpleTaskManager.Communication.Request;
using SimpleTaskManager.Communication.Response;

namespace SimpleTaskManager.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TaskController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseTaskId), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrors), StatusCodes.Status400BadRequest)]
    public IActionResult Register([FromBody] RequestTask request)
    {
        var response = new RegisterTaskUseCase().Execute(request);

        return Created(string.Empty, response);
    }

    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrors), StatusCodes.Status400BadRequest)]
    public IActionResult Update([FromRoute] string id, [FromRoute] RequestTask request)
    {
        var useCase = new UpdateTaskUsaCase();
        var responseErrors = useCase.Execute(id, request);

        if (responseErrors.errors.Count > 0)
            return StatusCode(StatusCodes.Status400BadRequest, responseErrors);
            
        return NoContent();
    }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrors), StatusCodes.Status400BadRequest)]
    public IActionResult Delete([FromRoute] string id)
    {
        var useCase = new DeleteTaskUseCase();
        var response = useCase.Execute(id);

        if (response.errors.Count > 0)
            return StatusCode(StatusCodes.Status400BadRequest, response);

        return NoContent();
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResponseTask), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult GetById([FromRoute] string id)
    {
        var useCase = new GetTaskByIdUseCase();
        var response = useCase.Execute(id);

        if (response == null)
            return NoContent();

        return Ok(response);
    }

    [HttpGet]
    [ProducesResponseType(typeof(ResponseAllTasks), StatusCodes.Status200OK)]
    public IActionResult GetAll()
    {
        var useCase = new GetAllTasksUseCase();
        var response = useCase.Execute();

        if (response.ResponseTasks.Count > 0)
            return Ok(response);

        return NoContent();
    }
}
