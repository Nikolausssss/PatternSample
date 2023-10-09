namespace UsersService;

/// <summary>Представляет класс пользователя.</summary>
public class User
{
    /// <summary>Инициализирует <see cref="User"/>.</summary>
    /// <param name="id">Идентификатор пользователя.</param>
    /// <param name="name">Имя пользователя.</param>
    /// <param name="age">Возраст пользователя.</param>
    internal User(int id, string name, int age)
    {
        Id = id;
        Name = name;
        Age = age;
    }


    /// <summary>Возвращает идентификатор пользователя.</summary>
    public int Id { get; }

    /// <summary>Возвращает имя пользователя.</summary>
    public string Name { get; }

    /// <summary>Возвращает возраст пользователя.</summary>
    public int Age { get; }
    
    public override string ToString()
    {
        return Name;
    }
}
