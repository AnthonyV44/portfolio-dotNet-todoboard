using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using VforV.Portfolio.DotNet.ToDoBoard.Domain.Model;
using VforV.Portfolio.DotNet.ToDoBoard.Entity;

namespace VforV.Portfolio.DotNet.ToDoBoard.Domain.v1.Query;

public static class GetBoards
{
    public sealed class Query : IRequest<IReadOnlyList<IBoard>>
    {
        public Query()
        {
        }
    }

    public sealed class Handler : QueryHandlerEntityBase<Entity.Model.Board>,
        IRequestHandler<Query, IReadOnlyList<IBoard>>
    {
        public Handler(IEntityDbContext dbContext, IMapper mapper, ILogger logger)
            : base(dbContext, mapper, logger)
        {
        }

        public async Task<IReadOnlyList<IBoard>> Handle(Query request, CancellationToken cancellationToken)
        {
            var boardEntities =
                await _dbContext
                    .Boards
                    .Include(i => i.Owner)
                    .Include(i => i.CreatedByUser)
                    .Include(i => i.ModifiedByUser)
                    .Include(i => i.DeletedByUser)
                    .AsNoTracking()
                    .ToListAsync(cancellationToken);

            return _mapper.Map<List<Board>>(boardEntities);
        }
    }
}