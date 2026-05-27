using PMT.Domain.Entities;

namespace PMT.Application.Interfaces;

public interface IProjectRepository
{
    Task<List<Project>> GetAllAsync();

    // 🔥 ADD THIS
    Task Add(Project project);
    Task<Project?> GetByIdAsync(int id);
    Task Delete(Project project);
}