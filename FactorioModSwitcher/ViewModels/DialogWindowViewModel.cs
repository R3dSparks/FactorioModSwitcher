using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FactorioModSwitcher.ViewModels
{
    public class DialogWindowViewModel
    {

        private Window currentWindow;

        public string Title { get; set; }

        public string Message { get; set; }

        private RelayCommand m_click_ok;

        private RelayCommand m_click_cancel;

        public ICommand Click_Ok
        {
            get
            {
                if (m_click_ok == null)
                    m_click_ok = new RelayCommand(ok);

                return m_click_ok;
            }
        }

        public ICommand Click_Cancel
        {
            get
            {
                if (m_click_cancel == null)
                    m_click_cancel = new RelayCommand(cancel);

                return m_click_cancel;
            }
        }

        public DialogWindowViewModel(Window window, string title, string message)
        {
            currentWindow = window;
            Title = title;
            Message = message;
        }

        private void ok()
        {
            currentWindow.DialogResult = true;

            currentWindow.Close();
        }

        private void cancel()
        {
            currentWindow.DialogResult = false;

            currentWindow.Close();
        }
    }
}
