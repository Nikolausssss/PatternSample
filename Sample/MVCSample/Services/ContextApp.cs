using MVCSample.Controllers;
using MVCSample.Views;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using UsersService;

namespace MVCSample.Services;

/// <summary>
/// Представляет контекст исполняемого приложения.<br/>
/// По сути жалкая породия контейнера сервисов.
/// </summary>
public class ContextApp
{
    private readonly UsersView _userView;
    private readonly UsersRepository _usersRepository;
    private readonly ModelActionListenerService _actionListenerService;


    /// <summary>Инициализирует <see cref="ContextApp"/>.</summary>
    /// <param name="usersRepository">Репозиторий пользователей.</param>
    public ContextApp(UsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
        
        _actionListenerService = new ModelActionListenerService();
        _usersRepository.UsersChanged += (s, e) => _actionListenerService.UpdateAll(_usersRepository.GetUsers());
        _actionListenerService.UpdateAll(_usersRepository.GetUsers());

        _userView = new UsersView(new UsersController(this, usersRepository), _actionListenerService);
    }


    /// <summary>Запускает приложение и начальную форму.</summary>
    public void Run()
    {
        Application.Run(_userView);
    }

    /// <summary>Открывает View редактирования пользователя.</summary>
    /// <param name="user">Редактируемый пользователь.</param>
    public void ShowEditUserView(User user)
    {
        new EditUserView(new EditUserController(this, _usersRepository, user)).Show();
    }

    /// <summary>Открывает View регистрации нового пользователя.</summary>
    public void ShowRegisterUserView()
    {
        new EditUserView(new RegisterUserController(this, _usersRepository)).Show();

    }

    /// <summary>Открывает View удаления пользователя.</summary>
    /// <param name="user">Удаляемый пользователь</param>
    public void ShowDeleteUserView(User user) 
    {
        new DeleteUserView(new DeleteUserController(_usersRepository, user)).Show();
    }

    /// <summary>Отображает сообщение.</summary>
    /// <param name="message">Сообщение.</param>
    public void ShowMessageView(string message)
    {
        MessageBox.Show(message, "Сообщение");
    }
}
