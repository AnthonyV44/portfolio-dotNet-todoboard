using System.ComponentModel.DataAnnotations;
using VforV.Portfolio.DotNet.ToDoBoard.Entity.Model.Common;

namespace VforV.Portfolio.DotNet.ToDoBoard.Entity.Model;

public class Board : IBoard
{
    // IBoard

    [Required]
    [MaxLength(256)]
    public string Title { get; set; } = null!;

    [MaxLength(2048)]
    public string? Description { get; set; }

    public bool IsArchived { get; set; }

    public List<TaskItem> TaskItems { get; set; } = null!;
    IEnumerable<ITaskItem> IBoard.TaskItems => TaskItems;

    public string? Metadata { get; set; }

    public User Owner { get; set; } = null!;
    IUser IBoard.Owner => Owner;
    public int OwnerId { get; set; }

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

    public Board()
    {
        TaskItems = new List<TaskItem>();
    }
}