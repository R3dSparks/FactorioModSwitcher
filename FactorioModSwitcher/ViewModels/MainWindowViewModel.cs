using FactorioModSwitcher.Business;
using FactorioModSwitcher.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FactorioModSwitcher.ViewModels
{
    public class MainWindowViewModel : BaseViewModell
    {
        private FactorioModSwitcherLogic m_logic;

        private RelayCommand m_click_switch;

        public ICommand Click_Switch
        {
            get
            {
                if (m_click_switch == null)
                    m_click_switch = new RelayCommand(switchProfile);

                return m_click_switch;
            }
        }

        /// <summary>
        /// Currently selected profile
        /// </summary>
        public Profile SelectedProfile { get; set; }

        /// <summary>
        /// List of all profiles
        /// </summary>
        public List<Profile> ProfileList
        {
            get => m_logic.Profiles;
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public MainWindowViewModel()
        {
            m_logic = new FactorioModSwitcherLogic();
        }

        /// <summary>
        /// Switch current mod list with the selected profile
        /// </summary>
        private void switchProfile()
        {
            m_logic.SwitchProfile(SelectedProfile);
        }
    }
}
