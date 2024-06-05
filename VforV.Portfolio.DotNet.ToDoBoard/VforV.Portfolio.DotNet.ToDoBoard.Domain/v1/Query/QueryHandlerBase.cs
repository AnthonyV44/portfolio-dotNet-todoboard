using AutoMapper;
using Microsoft.Extensions.Logging;
using VforV.Portfolio.DotNet.ToDoBoard.Entity;

namespace VforV.Portfolio.DotNet.ToDoBoard.Domain.v1.Query;

public abstract class QueryHandlerBase : DomainHandlerBase
{
    protected QueryHandlerBase(IEntityDbContext dbContext, IMapper mapper, ILogger logger) 
        : base(dbContext, mapper, logger)
    {
    }
}