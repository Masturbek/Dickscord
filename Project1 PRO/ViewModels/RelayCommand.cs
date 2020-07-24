using System;
using System.Windows.Input;

namespace Progect1.ViewModels
{
    /*
     * Реализаций ICommand уйма и все сводится к тому, как она будет в дальнейшем использоваться.
     * Если нам не нужна проверка CanExecute, то можно вовсе задать так:
     * 
     * private Action action;
     * public RelayCommand(Action action) => this.action = action;
     * public bool CanExecute(object parameter) => true;
     * #pragma warning disable CS0067
     * public event EventHandler CanExecuteChanged;
     * #pragma warning restore CS0067
     * public void Execute(object parameter) => action();
     * 
     * Всего пару строк кода, которые будут обрабатывать нужное действие, но не следить за "нужно ли его выполнять"
     * Я буду использовать чуть посложнее и с возможностью задать CanExecute (хоть он тут и не нужен).
     */

    public class RelayCommand<T> : ICommand
    {
        #region Fields

        readonly Action<T> _execute = null;
        readonly Predicate<T> _canExecute = null;

        #endregion

        #region Constructors

        public RelayCommand(Action<T> execute) : this(execute, null) { }

        public RelayCommand(Action<T> execute, Predicate<T> canExecute)
        {
            _execute = execute ?? throw new ArgumentNullException("execute");
            _canExecute = canExecute;
        }

        #endregion

        #region ICommand Members

        public bool CanExecute(object parameter) => _canExecute == null || _canExecute((T)parameter);

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public void Execute(object parameter) => _execute((T)parameter);

        #endregion
    }
}
