using Asp.Versioning;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VforV.Portfolio.DotNet.ToDoBoard.WebApi.Model.v1;
using VforV.Portfolio.DotNet.ToDoBoard.WebApi.Model.v1.Requests;
using VforV.Portfolio.DotNet.ToDoBoard.WebApi.Model.v1.Responses;

namespace VforV.Portfolio.DotNet.ToDoBoard.WebApi.Controllers.v1;

// TODO: version
[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion(1.0)]
[Produces("application/json")]
[Consumes("application/json")]
public class TaskItemController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly ILogger<TaskItemController> _logger;

    public TaskItemController(IMediator mediator, IMapper mapper, ILogger<TaskItemController> logger)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    [HttpGet(Name = "GetTaskItems")]
    [ProducesResponseType(typeof(GetTaskItemsResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public Task<ActionResult<IEnumerable<TaskItem>>> GetTaskItemsAsync()
    {
        throw new NotImplementedException();
    }

    [HttpGet("{identifier:guid}", Name = "GetTaskItem")]
    [ProducesResponseType(typeof(TaskItem), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public Task<ActionResult<TaskItem>> GetTaskItemAsync([FromRoute] Guid identifier)
    {
        throw new NotImplementedException();
    }

    [HttpPost(Name = "CreateTaskItem")]
    [ProducesResponseType(typeof(TaskItem), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public Task<ActionResult<TaskItem>> CreateTaskItemAsync([FromBody] CreateTaskItemRequest request)
    {
        throw new NotImplementedException();
    }

    [HttpPut("{identifier:guid}", Name = "UpdateTaskItem")]
    [ProducesResponseType(typeof(TaskItem), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public Task<ActionResult<TaskItem>> UpdateTaskItemAsync([FromRoute] Guid identifier,
        [FromBody]
        UpdateTaskItemRequest request)
    {
        throw new NotImplementedException();
    }

    [HttpDelete("{identifier:guid}", Name = "DeleteTaskItem")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public Task<IActionResult> DeleteTaskItemAsync([FromRoute] Guid identifier)
    {
        throw new NotImplementedException();
    }

    [HttpPost("{identifier:guid}/archive", Name = "ArchiveTaskItem")]
    public Task<IActionResult> ArchiveTaskItemAsync(Guid identifier)
    {
        throw new NotImplementedException();
    }
}