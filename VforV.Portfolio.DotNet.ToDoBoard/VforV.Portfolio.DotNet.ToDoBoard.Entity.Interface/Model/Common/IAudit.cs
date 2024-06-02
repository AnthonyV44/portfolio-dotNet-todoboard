namespace VforV.Portfolio.DotNet.ToDoBoard.Entity.Model.Common;

public interface IAudit
{
    IUser CreatedByUser { get; }
    int CreatedByUserId { get; }
    DateTime CreatedOnDate { get; }

    IUser ModifiedByUser { get; }
    int ModifiedByUserId { get; }
    DateTime ModifiedOnDate { get; }

    bool IsDeleted { get; }

    IUser? DeletedByUser { get; }
    int? DeletedByUserId { get; }
    DateTime? DeletedOnDate { get; }
}