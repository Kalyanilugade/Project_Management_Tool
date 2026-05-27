using PMT.Application.DTOs;
using PMT.Application.Interfaces;
using PMT.Domain.Entities;

namespace PMT.Application.Services;

public class ProjectService : IProjectService
{
    private readonly IProjectRepository _repo;
    private readonly ITaskRepository _taskRepo;
    public ProjectService(
        IProjectRepository repo,
        ITaskRepository taskRepo
    )
    {
        _repo = repo;
        _taskRepo = taskRepo;
    }

    public async Task<List<Project>> GetAllProjects()
    {
        return await _repo.GetAllAsync();
    }

    public async Task CreateProject(CreateProjectDto dto)
    {
        var project = new Project
        {
            Name = dto.Name,
            Description = dto.Description
        };

        // 🔥 FIX HERE
        await _repo.Add(project);
    }
    public async Task DeleteProject(int id)
    {
        var project = await _repo.GetByIdAsync(id);

        if (project == null)
            throw new Exception("Project not found");

        await _repo.Delete(project);
    }
    public async Task AssignTask(int projectId, AssignTaskDto dto)
    {
        var project = await _repo.GetByIdAsync(projectId);

        if (project == null)
            throw new Exception("Project not found");

        var task = new TaskItem
        {
            Title = dto.Title,
            AssignedTo = dto.AssignedTo,
            ProjectId = projectId
        };

        await _taskRepo.Add(task);
    }
}