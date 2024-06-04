using Microsoft.AspNetCore.Mvc;
using VforV.Portfolio.DotNet.ToDoBoard.WebApi.Model.v1;
using VforV.Portfolio.DotNet.ToDoBoard.WebApi.Model.v1.Requests;
using VforV.Portfolio.DotNet.ToDoBoard.WebApi.Model.v1.Responses;

namespace VforV.Portfolio.DotNet.ToDoBoard.WebApi.Controllers.v1;

// TODO: version
[ApiController]
[Route("[controller]")]
// [Route("api/v{v:apiVersion}/[controller]")]
// [ApiVersion("1.0")]
[Produces("application/json")]
[Consumes("application/json")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    // private readonly IMediator _mediator;
    // private readonly IMapper _mapper;

    public UserController(ILogger<UserController> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    [HttpGet(Name = "GetUsers")]
    [ProducesResponseType(typeof(GetUsersResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public Task<ActionResult<IEnumerable<User>>> GetUsersAsync()
    {
        throw new NotImplementedException();
    }

    [HttpGet("{identifier:guid}", Name = "GetUser")]
    [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public Task<ActionResult<User>> GetUserAsync([FromRoute] Guid identifier)
    {
        throw new NotImplementedException();
    }

    [HttpPost(Name = "CreateUser")]
    [ProducesResponseType(typeof(User), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public Task<ActionResult<User>> CreateUserAsync([FromBody] CreateUserRequest request)
    {
        throw new NotImplementedException();
    }

    [HttpPut("{identifier:guid}", Name = "UpdateUser")]
    [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public Task<ActionResult<User>> UpdateUserAsync([FromRoute] Guid identifier, [FromBody] UpdateBoardRequest request)
    {
        throw new NotImplementedException();
    }

    [HttpDelete("{identifier:guid}", Name = "DeleteUser")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public Task<IActionResult> DeleteUserAsync([FromRoute] Guid identifier)
    {
        throw new NotImplementedException();
    }

    [HttpPost("{identifier:guid}/archive", Name = "ArchiveUser")]
    public Task<IActionResult> ArchiveUserAsync(Guid identifier)
    {
        throw new NotImplementedException();
    }
}