using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using VforV.Portfolio.DotNet.ToDoBoard.Domain.Model;
using VforV.Portfolio.DotNet.ToDoBoard.Entity;

namespace VforV.Portfolio.DotNet.ToDoBoard.Domain.v1.Command;

public static class CreateBoard
{
    public sealed class Command : IRequest<IBoard>
    {
        public IBoard Board { get; }

        public Command(IBoard board)
        {
            Board = board;
        }
    }

    public sealed class Handler : CommandHandlerEntityBase<Entity.Model.Board>, IRequestHandler<Command, IBoard>
    {
        public Handler(
            IEntityDbContext dbContext,
            IUnitOfWork<IEntityDbContext> unitOfWork,
            IMapper mapper,
            IValidator<Entity.Model.Board> validator,
            ILogger logger)
            : base(dbContext, unitOfWork, mapper, validator, logger)
        {
        }

        public async Task<IBoard> Handle(Command request, CancellationToken cancellationToken)
        {
            LogCreateEntityAttempt();
            LogDomainDebug(request.Board);

            var boardEntity = _mapper.Map<Entity.Model.Board>(request.Board);
            LogEntityDebug(boardEntity);

            await ValidateAsync(boardEntity, cancellationToken);

            var createdBoard = await _dbContext.Boards.AddAsync(boardEntity, cancellationToken);
            await _unitOfWork.CompleteAsync(cancellationToken);
            boardEntity = createdBoard.Entity;

            LogCreateEntitySuccess(boardEntity);
            LogEntityDebug(boardEntity);

            return _mapper.Map<Board>(boardEntity);
        }
    }
}