using VforV.Portfolio.DotNet.ToDoBoard.Entity.Model.Common;

namespace VforV.Portfolio.DotNet.ToDoBoard.Entity.Model;

public interface IPriority : IEntity, IEntityId, IEntityIdentifier, IActivate, IAudit
{
    string Title { get; }

    string? Description { get; }

    int Value { get; }

    string? Metadata { get; }

    IEnumerable<ITaskItem> TaskItems { get; }
}