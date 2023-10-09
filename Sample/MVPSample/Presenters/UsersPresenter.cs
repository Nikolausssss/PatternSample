using MVPSample.Common;

using System;

using UsersService;

namespace MVPSample.Presenters;


/// <summary>
/// Представляет реализацию презентера для управления пользователями. В данном примере он один для всех окон.<br/>
/// Важно отметиь, что можно релизовать презентер для каждого View, тем самым распределить обязанности между ними.
/// </summary>
internal class UsersPresenter
{
    private readonly IUsersListView _usersListView;
    private readonly IUserEditView _editUserView;
    private readonly IUserEditView _registerUserView;
    private readonly IUserDeleteView _deleteUserView;
    private readonly IMessageView _messageView;
    private readonly UsersRepository _usersRepository;


    /// <summary>
    /// Инициализирует <see cref="UsersPresenter"/>
    /// </summary>
    /// <param name="usersListView">View для отображения списка пользователей</param>
    /// <param name="editUserView">View для редактирования данных пользователя</param>
    /// <param name="registerUserView">View для регистрации нового пользователя</param>
    /// <param name="deleteUserView">View для удаления пользователя</param>
    /// <param name="usersRepository">Репозиторий с пользователями.</param>
    public UsersPresenter(IUsersListView usersListView,
                          IUserEditView editUserView,
                          IUserEditView registerUserView,
                          IUserDeleteView deleteUserView,
                          IMessageView messageView,
                          UsersRepository usersRepository)
    {
        _usersRepository = usersRepository;

        _editUserView = editUserView;
        _registerUserView = registerUserView;
        _deleteUserView = deleteUserView;
        _messageView = messageView;
        _usersListView = usersListView;

        _usersRepository.UsersChanged += (s, e) =>
        {
            _usersListView.UpdateUsers(_usersRepository.GetUsers());
        };

        _usersListView.SetPresenter(this);
        _usersListView.UpdateUsers(_usersRepository.GetUsers());
    }


    /// <summary>Начинает процесс регистрации нового пользователя</summary>
    public void StartRegisterUser()
    {
        if (!_registerUserView.Show())
        {
            return;
        }

        try
        {
            _usersRepository.RegisterNewUser(_registerUserView.UserName,
                                             _registerUserView.UserAge);
        }
        catch (Exception e)
        {
            _messageView.ShowMessage(e.Message);
        }
    }

    /// <summary>Начинает процесс изменения данных пользователя</summary>
    public void StartEditUser()
    {
        User user = _usersListView.SelectedUser;

        _editUserView.Id = user.Id;
        _editUserView.UserName = user.Name;
        _editUserView.UserAge = user.Age;

        while (true)
        {
            if (!_editUserView.Show())
            {
                return;
            }

            try
            {
                _usersRepository.SaveEdited(_editUserView.Id,
                                            _editUserView.UserName,
                                            _editUserView.UserAge);
                return;
            }
            catch (Exception e)
            {
                _messageView.ShowMessage(e.Message);
            }
        }
    }

    /// <summary>Начинает процесс удаления пользователя</summary>
    public void StartDeleteUser()
    {
        if (_deleteUserView.Show(_usersListView.SelectedUser))
        {
            _usersRepository.Remove(_usersListView.SelectedUser);
        }
    }
}
