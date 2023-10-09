namespace MVPSample.Common;

/// <summary>
/// Представляет View для редактирования пользователя
/// </summary>
internal interface IUserEditView
{
    /// <summary>Возвращает или задает Id пользователя</summary>
    int Id { get; set; }

    /// <summary>Возварщает или задает имя пользоватея</summary>
    string UserName { get; set; }

    /// <summary>Возвращает или задает возраст пользователя</summary>
    int UserAge { get; set; }

    /// <summary>
    /// Отображает View
    /// </summary>
    /// <returns>true - если требуется сохранить изменения, false - иначе</returns>
    bool Show();
}
