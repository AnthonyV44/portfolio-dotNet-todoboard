using Asp.Versioning;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VforV.Portfolio.DotNet.ToDoBoard.WebApi.Model.v1;
using VforV.Portfolio.DotNet.ToDoBoard.WebApi.Model.v1.Requests;
using VforV.Portfolio.DotNet.ToDoBoard.WebApi.Model.v1.Responses;

namespace VforV.Portfolio.DotNet.ToDoBoard.WebApi.Controllers.v1;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion(1.0)]
[Produces("application/json")]
[Consumes("application/json")]
public class BoardController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly ILogger<BoardController> _logger;

    public BoardController(IMediator mediator, IMapper mapper, ILogger<BoardController> logger)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    [HttpGet(Name = "GetBoards")]
    [ProducesResponseType(typeof(GetBoardsResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public Task<ActionResult<GetBoardsResponse>> GetBoardsAsync()
    {
        throw new NotImplementedException();
    }

    [HttpGet("{identifier:guid}", Name = "GetBoard")]
    [ProducesResponseType(typeof(Board), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public Task<ActionResult<Board>> GetBoardAsync([FromRoute] Guid identifier)
    {
        throw new NotImplementedException();
    }

    [HttpPost(Name = "CreateBoard")]
    [ProducesResponseType(typeof(Board), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public Task<ActionResult<Board>> CreateBoardAsync([FromBody] CreateBoardRequest request)
    {
        throw new NotImplementedException();
    }

    [HttpPut("{identifier:guid}", Name = "UpdateBoard")]
    [ProducesResponseType(typeof(Board), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public Task<ActionResult<Board>> UpdateBoardAsync([FromRoute] Guid identifier,
        [FromBody]
        UpdateBoardRequest request)
    {
        throw new NotImplementedException();
    }

    [HttpDelete("{identifier:guid}", Name = "DeleteBoard")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public Task<IActionResult> DeleteBoardAsync([FromRoute] Guid identifier)
    {
        throw new NotImplementedException();
    }

    [HttpPost("{identifier:guid}/archive", Name = "ArchiveBoard")]
    public Task<IActionResult> ArchiveBoardAsync(Guid identifier)
    {
        throw new NotImplementedException();
    }
}