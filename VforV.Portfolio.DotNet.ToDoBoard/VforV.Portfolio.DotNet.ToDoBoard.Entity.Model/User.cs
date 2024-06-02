using VforV.Portfolio.DotNet.ToDoBoard.Entity.Model.Common;

namespace VforV.Portfolio.DotNet.ToDoBoard.Entity.Model;

public class User : IUser
{
    // IUser

    public string EmailAddress { get; set; } = null!;

    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;

    public List<Board> OwnedBoards { get; set; }
    IEnumerable<IBoard> IUser.OwnedBoards => OwnedBoards;

    public List<TaskItem> OwnedTaskItems { get; set; }
    IEnumerable<ITaskItem> IUser.OwnedTaskItems => OwnedTaskItems;

    public List<TaskItem> AssignedTaskItems { get; set; }
    IEnumerable<ITaskItem> IUser.AssignedTaskItems => AssignedTaskItems;

    // IEntityId

    public int Id { get; set; }

    // IEntityIdentifier

    public Guid Identifier { get; set; }

    // IActivate

    public bool IsActive { get; set; }

    // IAudit

    public User CreatedByUser { get; set; } = null!;
    IUser IAudit.CreatedByUser => CreatedByUser;
    public int CreatedByUserId { get; set; }
    public DateTime CreatedOnDate { get; set; }

    public User ModifiedByUser { get; set; } = null!;
    IUser IAudit.ModifiedByUser => ModifiedByUser;
    public int ModifiedByUserId { get; set; }
    public DateTime ModifiedOnDate { get; set; }

    public bool IsDeleted { get; set; }

    public User? DeletedByUser { get; set; }
    IUser? IAudit.DeletedByUser => DeletedByUser;
    public int? DeletedByUserId { get; set; }
    public DateTime? DeletedOnDate { get; set; }

    public User()
    {
        OwnedBoards = new List<Board>();
        OwnedTaskItems = new List<TaskItem>();
        AssignedTaskItems = new List<TaskItem>();
    }
}