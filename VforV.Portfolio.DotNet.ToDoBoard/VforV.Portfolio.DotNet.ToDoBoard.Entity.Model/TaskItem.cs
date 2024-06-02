using System.ComponentModel.DataAnnotations;
using VforV.Portfolio.DotNet.ToDoBoard.Entity.Model.Common;

namespace VforV.Portfolio.DotNet.ToDoBoard.Entity.Model;

public class TaskItem : ITaskItem
{
    // ITaskItem

    [Required]
    [MaxLength(256)]
    public string Title { get; set; } = null!;

    [MaxLength(2048)]
    public string? Description { get; set; }

    public Board Board { get; set; } = null!;
    IBoard ITaskItem.Board => Board;
    public int BoardId { get; set; }

    public Priority Priority { get; set; } = null!;
    IPriority ITaskItem.Priority => Priority;
    public int PriorityId { get; set; }

    public List<Tag> Tags { get; set; }
    IEnumerable<ITag> ITaskItem.Tags => Tags;

    public bool IsComplete { get; set; }
    public bool IsArchived { get; set; }

    public string? Metadata { get; set; }

    public User Owner { get; set; } = null!;
    IUser ITaskItem.Owner => Owner;
    public int OwnerId { get; set; }
    
    public User? AssignedTo { get; set; }
    IUser? ITaskItem.AssignedTo => AssignedTo;
    public int? AssignedToId { get; set; }

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

    public TaskItem()
    {
        Tags = new List<Tag>();
    }
}