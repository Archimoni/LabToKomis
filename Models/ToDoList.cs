namespace ToDoApi.Models;

public class ToDoList
{
    public int Id { get; set; }
    public string Title { get; set; }           // Название списка
    public DateTime CreatedAt { get; set; }     // Дата создания

    public int UserId { get; set; }
    public User User { get; set; }

    public ICollection<ToDo> ToDos { get; set; }
}