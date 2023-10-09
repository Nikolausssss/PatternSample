namespace UsersService;

/// <summary>
/// Менеджер доступа к источнику пользователей.<br/>
/// Служит демонстрацией паттерна Стратегия.
/// </summary>
public interface IManagementUserStrategy
{
    /// <summary>Загузить пользователей.</summary>
    /// <returns>Массив пользователей.</returns>
    User[] LoadUsers();

    /// <summary>Сохранить пользователей.</summary>
    /// <param name="users">Массив пользователей.</param>
    void SaveUsers(User[] users);
}
