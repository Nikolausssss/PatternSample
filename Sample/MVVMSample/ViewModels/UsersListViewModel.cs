using MVVMSample.Utilities;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using UsersService;

namespace MVVMSample.ViewModels;

/// <summary>Представляет ViewModel списка пользователей.</summary>
internal class UsersListViewModel : BindableBase
{
    private readonly UsersRepository _usersRepository;

    private UserViewModel _selectedUser;
    private RelayCommand _addNewUserCommand;
    private RelayCommand _saveChangesCommand;
    private RelayCommand _deleteUserCommand;

    public UsersListViewModel(UsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
      
        foreach (var user in usersRepository.GetUsers())
        {
            Users.Add(new UserViewModel(user));
        }

        // Обновление Users по изменениям в репозиториии.
        // Лучше продумать и для других действий кроме Added.
        _usersRepository.UsersChanged += (s, e) =>
        {
            if (e.Action == UserAction.Added)
            {
                var newUser = new UserViewModel(e.NewUser);
                Users.Add(newUser);
                SelectedUser = newUser;
                return;
            }
        };
    }


    /// <summary>Возварщает или задает выбранного пользователя.</summary>
    public UserViewModel SelectedUser
    {
        get => _selectedUser;
        set
        {
            if (_selectedUser != null) 
            {
                SaveChanges(_selectedUser);    
            }

            SetProperty(ref _selectedUser, value);
        }
    }

    /// <summary>Возвращает список всех пользователей.</summary>
    public BindingList<UserViewModel> Users { get; } = new();

    /// <summary>Возварщает команду добавления новых пользователей.</summary>
    public ICommand AddNewUserCommand => _addNewUserCommand ??= new RelayCommand(() =>
    {
        _usersRepository.RegisterNewUser($"Пользователь{Users.Count + 1}", 20);
    });

    /// <summary>Возварщает команду сохранения всех изменений.</summary>
    public ICommand SaveChangesCommand => _saveChangesCommand ??= new RelayCommand(() =>
    {
        foreach (var user in Users)
        {
            SaveChanges(user);
        }
    });

    public ICommand DeleteUserCommand => _deleteUserCommand ??= new RelayCommand(() =>
    {
        _usersRepository.Remove(SelectedUser.User);
        Users.Remove(SelectedUser);
        SelectedUser = Users.FirstOrDefault();
    });

    private void SaveChanges(UserViewModel user)
    {
        if (user.Name != user.User.Name || user.Age != user.User.Age)
        {
            _usersRepository.SaveEdited(user.User.Id, user.Name, user.Age);
        }
    }
}
