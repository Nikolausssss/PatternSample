using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMSample.Utilities;

/// <summary>Реализация паттерна команда.</summary>
internal class RelayCommand : ICommand
{
    private readonly Action<object?> _execute;
    private readonly Func<object?, bool>? _canExecute;


    public event EventHandler? CanExecuteChanged;
    
    /// <summary>Инициализирует экземпляр <see cref="RelayCommand"/>.</summary>
    /// <param name="execute">Действие с параметром, которое будет выполнено командой.</param>
    /// <param name="canExecute">Проверяет возможность выполнения команды.</param>
    public RelayCommand(Action<object?> execute, Func<object?, bool>? canExecute = null)
    {
        _execute = execute;
        _canExecute = canExecute;
    }

    /// <summary>Инициализирует экземпляр <see cref="RelayCommand"/>.</summary>
    /// <param name="execute">Действие без параметра, которое будет выполнено командой.</param>
    /// <param name="canExecute">Проверяет возможность выполнения команды.</param>
    public RelayCommand(Action execute, Func<bool>? canExecute = null) 
        : this(p => execute(), canExecute == null ? null : p => canExecute()) { }


    public bool CanExecute(object? parameter)
    {
        return _canExecute == null || _canExecute(parameter);
    }

    public void Execute(object? parameter)
    {
        _execute(parameter);
    }

    /// <summary>Вызывает событие изменений условий возможности выполнения.</summary>
    public void RaiseCanExecuteChanged()
    {
        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}
