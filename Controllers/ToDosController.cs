using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoApi.Models;

namespace ToDoApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ToDosController : ControllerBase
{
    private readonly AppDbContext _context;

    public ToDosController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ToDo>>> GetToDos()
    {
        return await _context.ToDos.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ToDo>> GetToDo(int id)
    {
        var todo = await _context.ToDos.FindAsync(id);
        return todo == null ? NotFound() : todo;
    }

    [HttpPost]
    public async Task<ActionResult<ToDo>> PostToDo(ToDo todo)
    {
        _context.ToDos.Add(todo);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetToDo), new { id = todo.Id }, todo);
    }
}