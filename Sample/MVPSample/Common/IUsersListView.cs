using MVPSample.Presenters;

using System;

using UsersService;

namespace MVPSample.Common;


/// <summary>
/// Представляет View для отображения списка пользователей
/// </summary>
internal interface IUsersListView
{
    /// <summary>
    /// Устанавливает <see cref="UsersPresenter"/>
    /// </summary>
    /// <param name="presenter">Презентер)</param>
    void SetPresenter(UsersPresenter presenter);

    /// <summary>
    /// Обновляет пользователей на View
    /// </summary>
    /// <param name="users">Новые пользователи</param>
    void UpdateUsers(User[] users);

    /// <summary>Возвращает выбранного пользователя</summary>
    User SelectedUser { get; }
}
