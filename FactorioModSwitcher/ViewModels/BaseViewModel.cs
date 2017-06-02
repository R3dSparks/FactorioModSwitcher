using System.ComponentModel;

namespace FactorioModSwitcher.ViewModels
{
    public abstract class BaseViewModell : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
    }
}
