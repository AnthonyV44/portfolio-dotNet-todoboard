using VforV.Portfolio.DotNet.ToDoBoard.Entity.Model.Common;

namespace VforV.Portfolio.DotNet.ToDoBoard.Entity.Model;

public interface IUser : IEntity, IEntityId, IEntityIdentifier, IActivate, IAudit
{
    string EmailAddress { get; }

    string FirstName { get; }
    string LastName { get; }
    
    IEnumerable<IBoard> OwnedBoards { get; }
    IEnumerable<ITaskItem> OwnedTaskItems { get; }
    IEnumerable<ITaskItem> AssignedTaskItems { get; }
}