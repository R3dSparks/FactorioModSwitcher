using FactorioModSwitcher.Business;
using FactorioModSwitcher.Entities;
using FactorioModSwitcher.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FactorioModSwitcher
{
    /// <summary>
    /// Interaction logic for ProfileEditor.xaml
    /// </summary>
    public partial class ProfileEditor : Window
    {
        public ProfileEditor(FactorioModSwitcherLogic logic, Profile profile)
        {
            InitializeComponent();

            this.DataContext = new ProfileEditorViewModel(logic, profile);
        }
    }
}
