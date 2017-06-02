using System;
using System.Windows.Input;

namespace FactorioModSwitcher.ViewModels
{
    public class RelayCommand : ICommand
    {
        private Action action;

        public RelayCommand(Action action)
        {
            this.action = action;
        }

        public event EventHandler CanExecuteChanged = (sender, e) => { };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter) => true;

        /// <summary>
        /// Execute command
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            action();            
        }
    }
}
