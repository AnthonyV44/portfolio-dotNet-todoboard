using AutoMapper;
using Microsoft.Extensions.Logging;
using VforV.Portfolio.DotNet.ToDoBoard.Entity;

namespace VforV.Portfolio.DotNet.ToDoBoard.Domain.v1.Command;

public abstract class CommandHandlerBase : DomainHandlerBase
{
    protected readonly IUnitOfWork<IEntityDbContext> _unitOfWork;

    protected CommandHandlerBase(
        IEntityDbContext dbContext,
        IUnitOfWork<IEntityDbContext> unitOfWork,
        IMapper mapper,
        ILogger logger)
        : base(dbContext, mapper, logger)
    {
        _unitOfWork = unitOfWork;
    }
}