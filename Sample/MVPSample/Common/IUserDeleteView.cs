using UsersService;

namespace MVPSample.Common;

/// <summary>
/// Представляет View для удаления пользователя
/// </summary>
internal interface IUserDeleteView
{
    /// <summary>
    /// Отображает View
    /// </summary>
    /// <param name="user">Удаляемый пользователь</param>
    /// <returns>true - если принято решение удалить пользователя, иначе false</returns>
    bool Show(User user);
}
