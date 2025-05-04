namespace ToDoApi.Models;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }         // Имя пользователя
    public string Password { get; set; }     // Пароль
    public int Age { get; set; }             // Возраст
    public string Education { get; set; }    // Образование

    public ICollection<ToDoList> ToDoLists { get; set; }
}