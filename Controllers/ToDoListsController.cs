using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoApi.Models;

namespace ToDoApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ToDoListsController : ControllerBase
{
    private readonly AppDbContext _context;

    public ToDoListsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ToDoList>>> GetLists()
    {
        return await _context.ToDoLists.Include(l => l.ToDos).ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ToDoList>> GetList(int id)
    {
        var list = await _context.ToDoLists.Include(l => l.ToDos).FirstOrDefaultAsync(l => l.Id == id);
        return list == null ? NotFound() : list;
    }

    [HttpPost]
    public async Task<ActionResult<ToDoList>> PostList(ToDoList list)
    {
        list.CreatedAt = DateTime.UtcNow;
        _context.ToDoLists.Add(list);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetList), new { id = list.Id }, list);
    }
}