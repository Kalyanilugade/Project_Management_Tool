// TaskService.cs
using PMT.Application.Interfaces;
using PMT.Domain.Entities;

public class TaskService : ITaskService
{
    private readonly ITaskRepository _repo;

    public TaskService(ITaskRepository repo)
    {
        _repo = repo;
    }

    public async Task<List<TaskItem>> GetTasksByUser(string email)
    {
        return await _repo.GetTasksByUser(email);
    }
}