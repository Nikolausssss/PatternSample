namespace UsersService;

/// <summary>
/// Предназначен для хранения пользователей.<br/>
/// Адаптер нужен, так как сериализация требует наличия открытых get и set методов у свойства.<br/>
/// По сути является костылем и служит лишь для демонстрации паттерна Адаптер.<br/>
/// </summary>
public class UserAdapter
{
    public UserAdapter(User user) 
    {
        Id = user.Id;
        Name = user.Name;
        Age = user.Age;
    }

    public UserAdapter()
    {
        Name = string.Empty;
    }
    

    /// <summary>Возвращает или задает значение идентификатора пользователя.</summary>
    public int Id { get; set; }

    /// <summary>Возвращает или задает имя пользователя.</summary>
    public string Name { get; set; }

    /// <summary>Возвращает или задает значение возраста пользователя.</summary>
    public int Age { get; set; }
}
