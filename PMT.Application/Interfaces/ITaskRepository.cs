// ITaskRepository.cs
using PMT.Domain.Entities;

namespace PMT.Application.Interfaces;

public interface ITaskRepository
{
    Task Add(TaskItem task);
    Task<List<TaskItem>> GetTasksByUser(string email);
}