using MVCSample.Services;

using System;

using UsersService;

namespace MVCSample.Controllers;

/// <summary>Представляет контроллер регистрации нового пользователя.</summary>
internal class RegisterUserController
{
    private readonly ContextApp _contextApp;
    private readonly UsersRepository _usersRepository;

    /// <summary>Инициализирует <see cref="RegisterUserController"/>.</summary>
    /// <param name="contextApp">Контекст приложения.</param>
    /// <param name="usersRepository">Репозиторий пользователей.</param>
    public RegisterUserController(ContextApp contextApp, UsersRepository usersRepository)
    {
        _contextApp = contextApp;
        _usersRepository = usersRepository;
    }


    /// <summary>Возвращает или задает имя пользователя.</summary>
    public string UserName { get; set; }

    /// <summary>Возвращает или задает возраст пользователя.</summary>
    public int UserAge { get; set; }


    /// <summary>Регистрирует пользователя.</summary>
    public void RegisterUser()
    {
        try
        {
            _usersRepository.RegisterNewUser(UserName, UserAge);
        }
        catch (Exception e)
        {

        }
    }
}
