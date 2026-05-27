using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PMT.Application.DTOs;
using PMT.Application.Interfaces;
using System.Security.Claims;

namespace PMT.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ProjectsController : ControllerBase
{
    private readonly IProjectService _projectService;
    private readonly ITaskService _taskService;   // ✅ ADD THIS

    // ✅ UPDATED CONSTRUCTOR
    public ProjectsController(
        IProjectService projectService,
        ITaskService taskService
    )
    {
        _projectService = projectService;
        _taskService = taskService;
    }

    // ✅ GET ALL PROJECTS
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var projects = await _projectService.GetAllProjects();
        return Ok(projects);
    }

    // 🔥 ADMIN ONLY - CREATE
    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> Create(CreateProjectDto dto)
    {
        await _projectService.CreateProject(dto);
        return Ok(new { message = "Project Created" });
    }

    // 🔥 ADMIN ONLY - DELETE
    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _projectService.DeleteProject(id);
        return Ok(new { message = "Project Deleted" });
    }

    // 🔥 MANAGER ONLY - ASSIGN TASK
    [Authorize(Roles = "Manager")]
    [HttpPost("{id}/assign")]
    public async Task<IActionResult> AssignTask(int id, AssignTaskDto dto)
    {
        await _projectService.AssignTask(id, dto);
        return Ok(new { message = "Task Assigned" });
    }

    // 🔥 USER ONLY - GET MY TASKS

    [HttpGet("my-tasks")]
    [Authorize(Roles = "User")]
    public async Task<IActionResult> GetMyTasks()
    {
        var email = User.Claims
            .FirstOrDefault(c => c.Type.Contains("name"))?.Value;

        if (string.IsNullOrEmpty(email))
            return Unauthorized();

        var tasks = await _taskService.GetTasksByUser(email);

        return Ok(tasks);
    }
}