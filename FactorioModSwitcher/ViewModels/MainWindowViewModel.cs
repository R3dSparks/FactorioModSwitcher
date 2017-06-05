using FactorioModSwitcher.Business;
using FactorioModSwitcher.Entities;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Windows;

namespace FactorioModSwitcher.ViewModels
{
    public class MainWindowViewModel
    {

        #region Private Properties

        private FactorioModSwitcherLogic m_logic;

        #endregion

        #region Commands

        private RelayCommand m_click_menu_newProfile;

        private RelayCommand m_click_menu_addFromClipboard;

        private RelayCommand m_click_switch;

        private RelayCommand m_click_contextMenu_edit;

        private RelayCommand m_click_contextMenu_delete;

        private RelayCommand m_click_contextMenu_copyToClipboard;

        private RelayCommand m_click_menu_saveModList;

        public ICommand Click_Menu_SaveModList
        {
            get
            {
                if (m_click_menu_saveModList == null)
                    m_click_menu_saveModList = new RelayCommand(saveModList);

                return m_click_menu_saveModList;
            }
        }

        public ICommand Click_Menu_AddFromClipboard
        {
            get
            {
                if (m_click_menu_addFromClipboard == null)
                    m_click_menu_addFromClipboard = new RelayCommand(addFromClipboard);

                return m_click_menu_addFromClipboard;
            }
        }

        public ICommand Click_ContextMenu_CopyToClipboard
        {
            get
            {
                if (m_click_contextMenu_copyToClipboard == null)
                    m_click_contextMenu_copyToClipboard = new RelayCommand(copyToClipboard);

                return m_click_contextMenu_copyToClipboard;
            }
        }

        public ICommand Click_Menu_NewProfile
        {
            get
            {
                if (m_click_menu_newProfile == null)
                    m_click_menu_newProfile = new RelayCommand(newProfile);

                return m_click_menu_newProfile;
            }
        }

        public ICommand Click_Switch
        {
            get
            {
                if (m_click_switch == null)
                    m_click_switch = new RelayCommand(switchProfile);

                return m_click_switch;
            }
        }

        public ICommand Click_ContextMenu_Edit
        {
            get
            {
                if (m_click_contextMenu_edit == null)
                    m_click_contextMenu_edit = new RelayCommand(editProfile);

                return m_click_contextMenu_edit;
            }
        }

        public ICommand Click_ContextMenu_Delete
        {
            get
            {
                if (m_click_contextMenu_delete == null)
                    m_click_contextMenu_delete = new RelayCommand(deleteProfile);

                return m_click_contextMenu_delete;
            }
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Currently selected profile
        /// </summary>
        public Profile SelectedProfile { get; set; }

        /// <summary>
        /// List of all profiles
        /// </summary>
        public ObservableCollection<Profile> ProfileList
        {
            get => m_logic.Profiles;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public MainWindowViewModel()
        {
            m_logic = new FactorioModSwitcherLogic();
        }

        #endregion

        #region Command Methods

        private void saveModList()
        {
            Profile profile = new Profile("Modlist save", m_logic.AvailableMods);

            ProfileEditor editor = new ProfileEditor(m_logic, profile);

            editor.ShowDialog();
        }

        private void addFromClipboard()
        {
            Profile profile = new Profile("Copied profile", m_logic.GetModListFromString(Clipboard.GetText()));

            ProfileEditor editor = new ProfileEditor(m_logic, profile);

            editor.ShowDialog();
        }

        private void copyToClipboard()
        {
            Clipboard.SetText(m_logic.GetProfileString(SelectedProfile));
        }

        private void newProfile()
        {
            ProfileEditor editor = new ProfileEditor(m_logic);

            editor.ShowDialog();
        }

        /// <summary>
        /// Switch current mod list with the selected profile
        /// </summary>
        private void switchProfile()
        {
            m_logic.SwitchProfile(SelectedProfile);
        }

        private void editProfile()
        {
            ProfileEditor editor = new ProfileEditor(m_logic, SelectedProfile);

            editor.ShowDialog();
        }

        private void deleteProfile()
        {
            DialogWindow confirmationWindow = new DialogWindow("Delete", "Do you really want to delete this profile?");

            confirmationWindow.ShowDialog();

            if(confirmationWindow.DialogResult == true)
            {
                m_logic.DeleteProfile(SelectedProfile);
            }
        }

        #endregion
    }
}
