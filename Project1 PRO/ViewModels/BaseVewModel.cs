using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

#nullable enable
namespace Progect1.ViewModels
{
    /*
     * Более правильная и удобная реализация интерфейса INotifyPropertyChanged
     * Благодаря [CallerMemberName] теперь не нужно писать имя свойства.
     * Также проверка на изменение, что позволяет оповещать интерфейс только тогда, когда значение действительно было изменено.
     * #nullable enable - фишка C# 8, которая позволяет предупредить нас, разработчиков о том, что мы пытаемся работать с NULL.
     * https://docs.microsoft.com/ru-ru/dotnet/csharp/nullable-references
     */

    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string? propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        public bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
