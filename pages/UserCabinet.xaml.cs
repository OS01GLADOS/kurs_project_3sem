using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Data.SqlClient;
using System.Data;

namespace kursProjectV3.pages
{
    public partial class UserCabinet : UserControl, ISwitchable
    {
        DataTable CurrentUserOrders;
        DBUsers CurrentUser;
        public UserCabinet()
        {
            InitializeComponent();
        }

        #region ISwitchable Members
        public void UtilizeState(object state)
        {
            SendedObject InData = state as SendedObject;
            CurrentUser = InData.SendedUser;
            ShowStatus.Text += " "+CurrentUser.UserStatusV;
            ShowRegistrationDate.Text += " " + CurrentUser.RegistrarionDateV.ToShortDateString();
            UsernameOut.Text = " " + CurrentUser.UsernameV;
            OrdersAmount();
            LoadOrders();
        }

        private void OrdersAmount()
        {
            string SqlRequest = "select Count(*) from ORDERS where client = '" + CurrentUser.UsernameV + "'";
            DataTable OrderCount = new DataTable();
            try
            {
                SqlDataAdapter adapter = ConnectionToDatabase.GetRequestResult(SqlRequest);
                adapter.Fill(OrderCount);
            }
            catch 
            {
                Switcher.Switch(new FirstPage());
            }
            
            ShowOrderAmount.Text = "Колличество заказов: " + OrderCount.Rows[0][0];
        }
        #endregion

        private void LoadOrders()
        {
            string sqlRequest = "select [Order],DepartingPoint, ArrivalPoint, Price*CargoWeight[OrderPrice], CargoWeight, OrderStatus "+
                                "from Orders Inner join Runs on Orders.Run = Runs.Run "+
                                "inner join Direction on Runs.Direction = Direction.Direction where Client = '"+CurrentUser.UsernameV+"'";
            CurrentUserOrders = new DataTable();
            try
            {
                SqlDataAdapter adapter = ConnectionToDatabase.GetRequestResult(sqlRequest);
                adapter.Fill(CurrentUserOrders);
            }
            catch
            {
                Switcher.Switch(new FirstPage());
            }
            if(CurrentUserOrders.Rows.Count ==0)
            {
                ThisUserOrders.Visibility = System.Windows.Visibility.Collapsed;
                tip.Visibility = Visibility.Collapsed;
                NoOrders.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                NoOrders.Visibility = System.Windows.Visibility.Collapsed;
                tip.Visibility = Visibility.Visible;
                ThisUserOrders.ItemsSource = CurrentUserOrders.DefaultView;
            }
        }

        private void ToPrevious(object sender, RoutedEventArgs e)
        { 
            SendedObject Send = new SendedObject(CurrentUser);
            Switcher.Switch(new UserMainPage(), Send);
        }

        private void ToStartPage(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new FirstPage());
        }

        private void PasswordEntered2_PasswordChanged(object sender, RoutedEventArgs e)
        {
            password2Error.Text = null;
            PasswordEntered2.BorderBrush = Brushes.LightBlue;
        }

        private void PasswordEntered1_PasswordChanged(object sender, RoutedEventArgs e)
        {
            password1Error.Text = null;
            PasswordEntered1.BorderBrush = Brushes.LightBlue;
        }

        private void PasswordOld_PasswordChanged(object sender, RoutedEventArgs e)
        {
            passwordOldError.Text = null;
            PasswordOld.BorderBrush = Brushes.LightBlue;
        }

        private void ChangePassword(object sender, RoutedEventArgs e)
        {
            if (PasswordOld.Password.Length == 0)
            {
                passwordOldError.Text = "Заполните это поле";
                PasswordOld.BorderBrush = Brushes.Red;
            }
            else
            {
                if (PasswordOld.Password != CurrentUser.UserPasswordV)
                {
                    passwordOldError.Text = "Введён неверный пароль";
                    PasswordOld.BorderBrush = Brushes.Red;
                }
            }
            if (PasswordEntered1.Password.Length ==0)
            {
                password1Error.Text = "Заполните это поле";
                PasswordEntered1.BorderBrush = Brushes.Red;
            }
            else
            {
                if (PasswordEntered1.Password.Length <4)
                {
                    password1Error.Text = "Пароль слишком короткий (минимум 4 символа)";
                    PasswordEntered1.BorderBrush = Brushes.Red;
                }
            }
            if (PasswordEntered2.Password.Length == 0)
            {
                password2Error.Text = "Заполните это поле";
                PasswordEntered2.BorderBrush = Brushes.Red;
            }
            else
            {
                if (PasswordEntered1.Password != PasswordEntered2.Password)
                {
                    password2Error.Text = "Пароли не совпадают";
                    PasswordEntered1.BorderBrush = Brushes.Red;
                    PasswordEntered2.BorderBrush = Brushes.Red;
                }
            }
            if (passwordOldError.Text == "" && password1Error.Text == "" && password2Error.Text == "")
            {
                MessageBoxResult messsageBox = MessageBox.Show("Вы действительно хотите изменить пароль", "Сменить пароль", MessageBoxButton.YesNo);
                if (messsageBox == MessageBoxResult.Yes)
                {
                    MessageBox.Show("Пароль успешно изменён");
                    string Sqlrequest = "update USERS set UserPassword = '"+PasswordEntered2.Password+"' where Username = '"+CurrentUser.UsernameV+"'";
                    CurrentUser.UserPasswordV = PasswordEntered2.Password;
                    try
                    {
                        ConnectionToDatabase.insertData(Sqlrequest);
                    }
                    catch
                    {
                        Switcher.Switch(new FirstPage());
                    }
                }
            }
        }

        private void ThisUserOrders_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MessageBoxResult messsageBox = MessageBox.Show("Вы действительно хотите отменить заказ?", "Отменить заказ", MessageBoxButton.YesNo);
            if (messsageBox == MessageBoxResult.Yes)
            {
                string sql = "delete orders where [order] = '"+ CurrentUserOrders.Rows[ThisUserOrders.SelectedIndex][0]+"'";
                try
                {
                    ConnectionToDatabase.insertData(sql);
                }
                catch
                {
                    Switcher.Switch(new FirstPage());
                }
                MessageBox.Show("Заказ отменён");
                OrdersAmount();
                LoadOrders();
            }
        }
    }
}
