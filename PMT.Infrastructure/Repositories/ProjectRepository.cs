using PMT.Application.Interfaces;
using PMT.Domain.Entities;
using PMT.Infrastructure.Data;

public class ProjectRepository : IProjectRepository
{
    private readonly AppDbContext _context;

    public ProjectRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Project>> GetAllAsync()
    {
        return _context.Projects.ToList();
    }

    public async Task Add(Project project)
    {
        _context.Projects.Add(project);
        await _context.SaveChangesAsync();
    }

    // ✅ ADD THIS
    public async Task<Project?> GetByIdAsync(int id)
    {
        return await _context.Projects.FindAsync(id);
    }

    // ✅ ADD THIS
    public async Task Delete(Project project)
    {
        _context.Projects.Remove(project);
        await _context.SaveChangesAsync();
    }
}