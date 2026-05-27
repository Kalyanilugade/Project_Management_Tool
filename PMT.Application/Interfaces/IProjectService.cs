using PMT.Application.DTOs;
using PMT.Domain.Entities;

namespace PMT.Application.Interfaces;

public interface IProjectService
{
    Task<List<Project>> GetAllProjects();
    Task CreateProject(CreateProjectDto dto);

    // ✅ ADD THIS
    Task DeleteProject(int id);
    Task AssignTask(int projectId, AssignTaskDto dto);
}