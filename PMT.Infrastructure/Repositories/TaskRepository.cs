// TaskRepository.cs
using PMT.Application.Interfaces;
using PMT.Domain.Entities;
using PMT.Infrastructure.Data;

public class TaskRepository : ITaskRepository
{
    private readonly AppDbContext _context;

    public TaskRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task Add(TaskItem task)
    {
        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();
    }

    public async Task<List<TaskItem>> GetTasksByUser(string email)
    {
        return _context.Tasks
            .Where(t => t.AssignedTo == email)
            .ToList();
    }
}