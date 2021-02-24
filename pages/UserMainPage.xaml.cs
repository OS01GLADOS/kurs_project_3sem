using System.Windows;
using System.Windows.Controls;

namespace kursProjectV3.pages
{
    public partial class UserMainPage : UserControl, ISwitchable
    {
        DBUsers CurrentUser;
        SendedObject Send;
        public UserMainPage()
        {
            InitializeComponent();
        }

        #region ISwitchable Members
        public void UtilizeState(object state)
        {
            SendedObject IncomeObject = state as SendedObject;
            CurrentUser=IncomeObject.SendedUser;
            GreetingsText.Text = GreetingsText.Text + " " + CurrentUser.UsernameV;
            if (CurrentUser.UserStatusV == "Admin" || CurrentUser.UserStatusV == "Carrier")
                DirectionsControl.Visibility = Visibility.Visible;
            if (CurrentUser.UserStatusV == "Admin")
                AccountControl.Visibility = Visibility.Visible;
        }
        #endregion

        private void ToUserCabinet(object sender, RoutedEventArgs e)
        {
            Send = new SendedObject(CurrentUser);
            Switcher.Switch(new UserCabinet(), Send);
        }

        private void ToAccountControl(object sender, RoutedEventArgs e)
        {
            Send = new SendedObject(CurrentUser);
            Switcher.Switch(new AccountControl(), Send);
        }

        private void ToFindDirection(object sender, RoutedEventArgs e)
        {
            ToFindDirection();
        }
        private void ToFindDirection()
        {
            Send = new SendedObject(CurrentUser);
            Switcher.Switch(new FindDirection(), Send);
        }

        private void ToRunsControl(object sender, RoutedEventArgs e)
        {
            Send = new SendedObject(CurrentUser);
            Switcher.Switch(new RunsControl2(), Send);
        }

        private void ToMessages(object sender, RoutedEventArgs e)
        {
            Send = new SendedObject(CurrentUser);
            Switcher.Switch(new Messages(), Send);
        }
    }
}
