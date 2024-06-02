using System.ComponentModel.DataAnnotations;

namespace VforV.Portfolio.DotNet.ToDoBoard.Entity.Model;

public class Tag : ITag
{
    // ITag

    [Required]
    [MaxLength(256)]
    public string Title { get; set; } = null!;

    [MaxLength(2048)]
    public string? Description { get; set; }

    public string? Metadata { get; set; }

    public List<TaskItem> TaskItems { get; set; }
    IEnumerable<ITaskItem> ITag.TaskItems => TaskItems;

    // IEntityId

    public int Id { get; set; }

    // IEntityIdentifier

    public Guid Identifier { get; set; }

    public Tag()
    {
        TaskItems = new List<TaskItem>();
    }
}