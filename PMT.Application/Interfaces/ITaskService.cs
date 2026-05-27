// ITaskService.cs
using PMT.Domain.Entities;

namespace PMT.Application.Interfaces;

public interface ITaskService
{
    Task<List<TaskItem>> GetTasksByUser(string email);
}