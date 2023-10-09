using System;
using System.Collections.Generic;

using UsersService;

namespace MVCSample.Services;

/// <summary>
/// Сервис сообщений для непрямой связи View c Model.<br/>
/// Это лишь один из вариантов и то не самый лучший для реализации передачи сообщений во View.
/// На более серьезном и большом проекте лучше использовать более универсальные инструменты.
/// </summary>
internal class ModelActionListenerService
{
    private List<Action<User[]>> _listeners = new();
    private User[] _users;

    /// <summary>Инициализирует <see cref="ModelActionListenerService"/>.</summary>
    public ModelActionListenerService()
    {
    }

    /// <summary>Добавляет слушателя.</summary>
    /// <param name="listener">Слушатель.</param>
    public void AddListener(Action<User[]> listener)
    {
        _listeners.Add(listener);
        listener.Invoke(_users);
    }

    /// <summary>Удаляет слушателя.</summary>
    /// <param name="listener">Слушатель.</param>
    public void RemoveListener(Action<User[]> listener)
    {
        _listeners.Remove(listener);
    }

    /// <summary>Обновляет состояние всех слушателей.</summary>
    /// <param name="users">Аргументы для передачи в слушатели.</param>
    public void UpdateAll(User[] users)
    {
        _users = users;
        foreach (var listener in _listeners)
        {
            listener.Invoke(users);
        }
    }
}
