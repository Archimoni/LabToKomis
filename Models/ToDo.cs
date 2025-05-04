namespace ToDoApi.Models;

public class ToDo
{
    public int Id { get; set; }
    public string Task { get; set; }                  // Текст задачи
    public bool IsCompleted { get; set; }             // Завершена ли
    public DateTime Deadline { get; set; }

    public string? Description { get; set; }            // Срок выполнения
    public PriorityLevel Priority { get; set; }       // Приоритет

    public int ToDoListId { get; set; }
    public ToDoList ToDoList { get; set; }
}

public enum PriorityLevel
{
    СрочноИВажно = 1,
    СрочноИНеважно = 2,
    НесрочноИВажно = 3,
    НесрочноИНеважно = 4
}