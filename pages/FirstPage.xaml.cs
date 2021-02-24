using System;
using System.Windows;
using System.Windows.Controls;

namespace kursProjectV3.pages
{
    public partial class FirstPage : UserControl, ISwitchable
    {
        public FirstPage()
        {
            InitializeComponent();
        }

        #region ISwitchable Members
        public void UtilizeState(object state)
        {
            throw new NotImplementedException();
        }
        #endregion

        private void EnterPage(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new EnterPage());
        }

        private void Registrate(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new Registration());
        }
    }
}
