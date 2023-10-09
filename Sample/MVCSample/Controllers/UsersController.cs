using MVCSample.Services;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UsersService;

namespace MVCSample.Controllers;

/// <summary>Представляет контроллер управления пользователями.</summary>
internal class UsersController
{
    private readonly ContextApp _contextApp;
    private readonly UsersRepository _usersRepository;

    /// <summary>Инициализирует <see cref="UsersController"/>.</summary>
    /// <param name="contextApp">Контекст приложения.</param>
    /// <param name="usersRepository">Репозиторий пользователей.</param>
    public UsersController(ContextApp contextApp, UsersRepository usersRepository)
    {
        _contextApp = contextApp;
        _usersRepository = usersRepository;
    }


    /// <summary>Регистрирует нового пользователя.</summary>
    public void RegisterUser()
    {
        _contextApp.ShowRegisterUserView();
    }

    /// <summary>Удаляет пользователя.</summary>
    /// <param name="user">Удаляемый пользователь.</param>
    public void DeleteUser(User user)
    {
        _contextApp.ShowDeleteUserView(user);
    }

    /// <summary>Редактирует пользователя.</summary>
    /// <param name="user">Редактируемый пользователь.</param>
    public void EditUser(User user)
    {
        _contextApp.ShowEditUserView(user);
    }
}
