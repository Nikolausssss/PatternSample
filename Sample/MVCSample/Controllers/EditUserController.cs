using MVCSample.Services;

using System;

using UsersService;

namespace MVCSample.Controllers;

/// <summary>Представлят контроллер, управляющий редактированием данных пользователя.</summary>
internal class EditUserController
{
    private readonly ContextApp _contextApp;
    private readonly UsersRepository _usersRepository;


    /// <summary>Инициализирует <see cref="EditUserController"/>.</summary>
    /// <param name="contextApp">Контекст приложения.</param>
    /// <param name="usersRepository">Репозиторий пользователей.</param>
    /// <param name="user">Редактируемый пользователь.</param>
    public EditUserController(ContextApp contextApp, UsersRepository usersRepository, User user)
    {
        _contextApp = contextApp;
        _usersRepository = usersRepository;
        UserId = user.Id;
        UserName = user.Name;
        UserAge = user.Age;
    }

    
    /// <summary>Возвращает идентификатор пользователя.</summary>
    public int UserId { get; }
    
    /// <summary>Возвращает или задает имя пользователя.</summary>
    public string UserName { get; set; }

    /// <summary>Возвращает или задает возраст пользователя.</summary>
    public int UserAge { get; set; }


    /// <summary>Сохраняет изменения.</summary>
    public void SaveChanges()
    {
        try
        {
            _usersRepository.SaveEdited(UserId, UserName, UserAge);
        }
        catch (Exception e)
        {
            _contextApp.ShowMessageView(e.Message);
        }
    }
}
