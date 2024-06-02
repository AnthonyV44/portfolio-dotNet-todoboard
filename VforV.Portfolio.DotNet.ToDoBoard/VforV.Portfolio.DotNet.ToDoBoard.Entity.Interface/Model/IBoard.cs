using VforV.Portfolio.DotNet.ToDoBoard.Entity.Model.Common;

namespace VforV.Portfolio.DotNet.ToDoBoard.Entity.Model;

public interface IBoard : IEntity, IEntityId, IEntityIdentifier, IActivate, IAudit
{
    string Title { get; }

    string? Description { get; }

    bool IsArchived { get; }
    
    IEnumerable<ITaskItem> TaskItems { get; }
    
    string? Metadata { get; }
    
    IUser Owner { get; }
    int OwnerId { get; }
}