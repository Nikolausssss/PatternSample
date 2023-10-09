using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MVVMSample.Utilities;

/// <summary>Шаблон с вспомогательными методами для реализации <see cref="INotifyPropertyChanged"/>.</summary>
internal abstract class BindableBase : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    /// <summary>Вызывает событие изменения свойства.</summary>
    /// <param name="propertyName">Название свойства. Может быть передано автоматически.</param>
    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    /// <summary>Устанавливает значение свойства и вызывает событие обновления.</summary>
    /// <typeparam name="T">Тип значения.</typeparam>
    /// <param name="source">Поле, в котором храниться старое значение свойства.</param>
    /// <param name="value">Новаое значение свойства.</param>
    /// <param name="propertyName">Название свойства. Может быть передано автоматически.</param>
    protected void SetProperty<T>(ref T source, T value, [CallerMemberName] string? propertyName = null)
    {
        if (source?.Equals(value) ?? false) return;

        source = value;
        OnPropertyChanged(propertyName);
    }
}
