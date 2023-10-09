using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace UsersService;

/// <summary>Представляет репозиторий пользователей.</summary>
public class UsersRepository
{
    public const int MaxAge = 120;
    public const int MinAge = 0;
    private List<User> _users = new();
    private IManagementUserStrategy _sourceUsers;


    /// <summary>Инициализирует <see cref="UsersRepository"/>.</summary>
    public UsersRepository(string sourceFile)
    {
        if (Path.GetExtension(sourceFile).ToLower() == ".xml")
        {
            _sourceUsers = new XMLUserStrategy(sourceFile);
        }
        else
        {
            _sourceUsers = new JSONUserStrategy(sourceFile);
        }
        LoadUsers();
    }

    private void LoadUsers()
    {
        _users.Clear();
        _users.AddRange(_sourceUsers.LoadUsers());
    }

    private void SaveUsers()
    {
        _sourceUsers.SaveUsers(GetUsers());
    }

    private static ArgumentException EmptyNameException() => new("Имя не может быть пустым", "name");
    private static ArgumentException InvalidAgeException() => new($"Возраст не может быть меньше {MinAge} и больше {MaxAge} лет", "age");
    private static ArgumentException NonexistentUserException(int id) => new($"Пользователя с таким Id={id} не существует", "id");

    private static bool IsEmptyName(string name) => string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name);
    private static bool IsInvalidAge(int age) => age <= MinAge || MaxAge < age;

    private int GenerateId()
    {
        return _users.Any() ? _users.Select(x => x.Id).Max() + 1 : 0;
    }

    private void OnUserChanged(User? newUser, User? oldUser, UserAction action)
    {
        UsersChanged?.Invoke(this, new UsersChangedEventArgs(newUser, oldUser, action));
    }

    /// <summary>
    /// Регистрирует нового пользователя.
    /// </summary>
    /// <param name="name">Имя пользователя. Не может быть пустым.</param>
    /// <param name="age">Возраст пользователя. Не может быть меньше <see cref="MinAge"/> или больше <see cref="MaxAge"/>.</param>
    /// <exception cref="ArgumentException">Возникает, если имя пустое или меньше <see cref="MinAge"/> или больше <see cref="MaxAge"/>.</exception>
    public void RegisterNewUser(string name, int age)
    {
        if (IsEmptyName(name))
        {
            throw EmptyNameException();
        }

        if (IsInvalidAge(age))
        {
            throw InvalidAgeException();
        }

        var newUser = new User(GenerateId(), name, age);
        _users.Add(newUser);
        OnUserChanged(newUser, null, UserAction.Added);
        SaveUsers();
    }

    /// <summary>Возвращает всех текущих пользователей.</summary>
    /// <returns>Текущие пользователи.</returns>
    public User[] GetUsers()
    {
        return _users.ToArray();
    }

    /// <summary>Сохраняет изменения пользователя.</summary>
    /// <param name="id">Идентификатор пользователя.</param>
    /// <param name="name">Имя пользователя.</param>
    /// <param name="age">Возраст пользователя.</param>
    /// <exception cref="ArgumentException"></exception>
    public void SaveEdited(int id, string name, int age)
    {
        User? oldUser = _users.FirstOrDefault(x => x.Id == id);
       
        if (oldUser == null) throw NonexistentUserException(id);
        if (IsEmptyName(name)) throw EmptyNameException();
        if (IsInvalidAge(age)) throw InvalidAgeException();

        var newUser = new User(oldUser.Id, name, age);
        
        _users.Remove(oldUser);
        _users.Add(newUser);

        OnUserChanged(newUser, oldUser, UserAction.Edit);
        SaveUsers();
    }

    /// <summary>Удаляет пользователя из репозитория.</summary>
    /// <param name="user">Удаляемый пользователь.</param>
    public void Remove(User user)
    {
        _users.Remove(user);
        OnUserChanged(null, user, UserAction.Remove);
        SaveUsers();
    }

    /// <summary>Возникает при изменении пользователей в репозитории.</summary>
    public event EventHandler<UsersChangedEventArgs>? UsersChanged;
}
