namespace PMT.Domain.Entities;

public class TaskItem
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;

    public string AssignedTo { get; set; } = string.Empty;

    public int ProjectId { get; set; }
    public Project? Project { get; set; }
}