using UsersService;

namespace MVCSample.Controllers;

/// <summary>Представляет контроллер для управления удалением пользователя.</summary>
internal class DeleteUserController
{
    private readonly UsersRepository _usersRepository;

    /// <summary>Инициализирует <see cref="DeleteUserController"/>.</summary>
    /// <param name="usersRepository">Репозиторий пользователей.</param>
    /// <param name="user">Удаляемый пользователь.</param>
    public DeleteUserController(UsersRepository usersRepository, User user) 
    {
        _usersRepository = usersRepository;
        User = user;
    }


    /// <summary>Возвращает удаляемого пользователя.</summary>
    public User User { get; }


    /// <summary>Удаляет пользователя.</summary>
    public void DeleteUser()
    {
        _usersRepository.Remove(User);
    }
}
