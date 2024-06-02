using VforV.Portfolio.DotNet.ToDoBoard.Entity.Model.Common;

namespace VforV.Portfolio.DotNet.ToDoBoard.Entity.Model;

public interface ITaskItem : IEntity, IEntityId, IEntityIdentifier, IActivate, IAudit
{
    string Title { get; }

    string? Description { get; }
    
    IBoard Board { get; }
    int BoardId { get; }

    IPriority Priority { get; }
    int PriorityId { get; }

    IEnumerable<ITag> Tags { get; }

    bool IsComplete { get; }
    bool IsArchived { get; }

    string? Metadata { get; }

    IUser Owner { get; }
    int OwnerId { get; }
    
    IUser? AssignedTo { get; }
    int? AssignedToId { get; }
}