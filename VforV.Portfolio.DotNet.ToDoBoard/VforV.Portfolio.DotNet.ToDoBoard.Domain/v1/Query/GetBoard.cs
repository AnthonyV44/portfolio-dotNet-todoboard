using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using VforV.Portfolio.DotNet.ToDoBoard.Domain.Model;
using VforV.Portfolio.DotNet.ToDoBoard.Entity;

namespace VforV.Portfolio.DotNet.ToDoBoard.Domain.v1.Query;

public static class GetBoard
{
    public sealed class Query : IRequest<IBoard>
    {
        public Guid Identifier { get; }

        public Query(Guid identifier)
        {
            Identifier = identifier;
        }
    }

    public sealed class Handler : QueryHandlerEntityBase<Entity.Model.Board>, IRequestHandler<Query, IBoard>
    {
        public Handler(IEntityDbContext dbContext, IMapper mapper, ILogger logger)
            : base(dbContext, mapper, logger)
        {
        }

        public async Task<IBoard> Handle(Query request, CancellationToken cancellationToken)
        {
            LogGetEntityAttempt(request.Identifier);

            var userEntity = await _dbContext
                .Set<Entity.Model.Board>()
                .Include(i => i.Owner)
                .Include(i => i.CreatedByUser)
                .Include(i => i.ModifiedByUser)
                .Include(i => i.DeletedByUser)
                .SingleOrDefaultAsync(e => e.Identifier == request.Identifier, cancellationToken);

            if (userEntity == null)
            {
                LogGetEntityNotFound(request.Identifier);
                throw DomainExceptionBuilder.EntityNotFound<Entity.Model.Board>(request.Identifier);
            }

            LogGetEntityFound(request.Identifier);

            return _mapper.Map<Board>(userEntity);
        }
    }
}