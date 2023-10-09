using System;

namespace UsersService;

/// <summary>Представляет аргументы события изменения пользователя.</summary>
public class UsersChangedEventArgs
{
    /// <summary>Инициализиует <see cref="UsersChangedEventArgs"/>.</summary>
    /// <param name="newUser">Новый пользователь.</param>
    /// <param name="oldUser">Старый пользователь.</param>
    /// <param name="action">Действие над пользователем.</param>
    public UsersChangedEventArgs(User? newUser, User? oldUser, UserAction action)
    {
        Action = action;

        if (action == UserAction.Edit && oldUser == null)
            throw new ArgumentNullException(nameof(oldUser),
                                            $"При изменении пользователя, пареметр {nameof(oldUser)} должен быть указан");

        if ((action == UserAction.Edit || action == UserAction.Added) && newUser == null)
            throw new ArgumentNullException(nameof(newUser),
                                            $"При добавлении или изменении пользователя, пареметр {nameof(newUser)} должен быть указан");
        
        if (action == UserAction.Remove && oldUser == null)
            throw new ArgumentNullException(nameof(oldUser),
                                            $"При удалении пользователя, пареметр {nameof(oldUser)} должен быть указан");

        NewUser = newUser;
        OldUser = oldUser;
    }


    /// <summary>Новый пользователь.</summary>
    public User? NewUser { get; }

    /// <summary>Старый пользователь.</summary>
    public User? OldUser { get; }

    /// <summary>Действие над пользователем.</summary>
    public UserAction Action { get; }
}
