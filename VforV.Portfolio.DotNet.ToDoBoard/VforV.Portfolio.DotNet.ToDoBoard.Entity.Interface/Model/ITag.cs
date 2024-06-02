using VforV.Portfolio.DotNet.ToDoBoard.Entity.Model.Common;

namespace VforV.Portfolio.DotNet.ToDoBoard.Entity.Model;

public interface ITag : IEntity, IEntityId, IEntityIdentifier
{
    string Title { get; }

    string? Description { get; }

    string? Metadata { get; }
    
    IEnumerable<ITaskItem> TaskItems { get; }
}