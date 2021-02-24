using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;

namespace kursProjectV3.pages
{
    public partial class AccountControl : UserControl, ISwitchable
    {
        DataTable UsersTable;
        DBUsers CurrentUser;
        public AccountControl()
        {
            InitializeComponent();
            SortPref.Items.Add("имени пользователя");
            SortPref.Items.Add("cтатусу");
            SortPref.Items.Add("рейтингу");
            SortPref.Items.Add("дате регистрации");
            SortOrder.Items.Add("по возрастанию");
            SortOrder.Items.Add("по убыванию");
        }

        #region ISwitchable Members
        public void UtilizeState(object state)
        {
            SendedObject InData = state as SendedObject;
            CurrentUser = InData.SendedUser;
        }
        #endregion

        private void ToUserMainPage(object sender, RoutedEventArgs e)
        {
            SendedObject Send = new SendedObject(CurrentUser);
            Switcher.Switch(new UserMainPage(), Send);
        }

        private void ToUserCabinet(object sender, RoutedEventArgs e)
        {
            SendedObject Send = new SendedObject(CurrentUser);
            Switcher.Switch(new UserCabinet(), Send);
        }

        private void PageLoaded(object sender, RoutedEventArgs e)
        {
            UpdateTable();
        }

        private void UpdateTable()
        {
            SqlDataAdapter adapter;
            string sqlRequest = "select Username, UserPassword, Userstatus, PhoneNumber, Convert(nvarchar,RegistrationDate,1)[RegistrationDate1], Ranking from USERS ";
            if (SearchVar.Text != "" && SearchVar.Text != null && SearchVar.Text != " ")
            {
                sqlRequest += "where ";
                switch (SearchParams.SelectedIndex)
                {
                    case 0:
                        sqlRequest += "Username";
                        break;
                    case 1:
                        sqlRequest += "PhoneNumber";
                        break;
                }
                sqlRequest += " like N'%"+SearchVar.Text+"%' ";
            }
            sqlRequest += "ORDER BY ";
            switch (SortPref.SelectedIndex)
            {
                case 0:
                    sqlRequest += "Username";
                    break;
                case 1:
                    sqlRequest += "Userstatus";
                    break;
                case 2:
                    sqlRequest += "Ranking";
                    break;
                case 3:
                    sqlRequest += "RegistrationDate";
                    break;
            }
            if (SortOrder.SelectedIndex == 1)
                sqlRequest += " Desc";
            UsersTable = new DataTable();
            try
            {
                adapter =ConnectionToDatabase.GetRequestResult(sqlRequest);
                adapter.Fill(UsersTable);
            }
            catch
            {
                Switcher.Switch(new FirstPage());
            }
            AllUsers.ItemsSource = UsersTable.DefaultView;
        }

        private void SortPref_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateTable();
        }

        private void SortOrder_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateTable();
        }

        private void SearchVar_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateTable();
        }

        private void AllUsers_Selected(object sender, RoutedEventArgs e)
        {
            switch (UsersTable.Rows[AllUsers.SelectedIndex][2])
            {
                case "User":
                    ShowStatus.SelectedIndex = 0;
                    break;
                case "Carrier":
                    ShowStatus.SelectedIndex = 1;
                    break;
                case "Admin":
                    ShowStatus.SelectedIndex = 2;
                    break;
            }
            ShowRanking.Value = Convert.ToDouble(UsersTable.Rows[AllUsers.SelectedIndex][5]);
            AboutAccount.Visibility = Visibility.Visible;
            ChangeSelectedAccount.Visibility = Visibility.Visible;
            {
                string sqlRequest = "select [Order],DepartingPoint, ArrivalPoint, Price*CargoWeight[OrderPrice], CargoWeight, OrderStatus " +
                                    "from Orders Inner join Runs on Orders.Run = Runs.Run " +
                                    "inner join Direction on Runs.Direction = Direction.Direction where Client = '" + UsersTable.Rows[AllUsers.SelectedIndex][0] + "'";
                DataTable CurrentUserOrders = new DataTable();
                try
                {
                    SqlDataAdapter adapter = ConnectionToDatabase.GetRequestResult(sqlRequest);
                    adapter.Fill(CurrentUserOrders);
                }
                catch
                {
                    Switcher.Switch(new FirstPage());
                }
                if (CurrentUserOrders.Rows.Count == 0)
                {
                    ThisUserOrders.Visibility = System.Windows.Visibility.Collapsed;
                }
                else
                {
                    ThisUserOrders.ItemsSource = CurrentUserOrders.DefaultView;
                }
                Status.Text = "Пользователь: " + Convert.ToString(UsersTable.Rows[AllUsers.SelectedIndex][0]) + "  Статус пользователя: " +Convert.ToString(UsersTable.Rows[AllUsers.SelectedIndex][2])+"  Рейтинг: "+ Convert.ToString(UsersTable.Rows[AllUsers.SelectedIndex][5]);
                AllOrders.Text = "Всего заказов: "+ Convert.ToString(CurrentUserOrders.Rows.Count);
            }
        }

        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            if (ChangePassword.Text.Length < 4 && ChangePassword.Text.Length!=0)
            {
                    PasswordError.Text = "Пароль слишком короткий (минимум 4 символа)";
                    ChangePassword.BorderBrush = Brushes.Red;
            }
            if ((ChangePhone.Text.Length < 12 || Regex.IsMatch(ChangePhone.Text, @"\D"))&& ChangePhone.Text.Length!=0)
            {
                PhoneError.Text = "Введите корректный номер мобильного телефона, начиная с цифры";
                ChangePhone.BorderBrush = Brushes.Red;
            }

            if (PhoneError.Text == "" && PasswordError.Text =="")
            {
                string sqlRequest = "Update USERS set Userstatus = '" + ShowStatus.Text+ "' where Username = '"+ Convert.ToString(UsersTable.Rows[AllUsers.SelectedIndex][0])+"'";
                if (ChangePassword.Text.Length != 0)
                {
                    sqlRequest += " Update USERS set UserPassword = '" + ChangePassword.Text + "' where Username = '" + Convert.ToString(UsersTable.Rows[AllUsers.SelectedIndex][0]) + "'";
                }
                if (ChangePhone.Text.Length != 0)
                {
                    sqlRequest += " Update USERS set PhoneNumber = '" + ChangePhone.Text + "' where Username = '" + Convert.ToString(UsersTable.Rows[AllUsers.SelectedIndex][0]) + "'";
                }
                sqlRequest += "Update USERS set Ranking = '" + ShowRanking.Value + "' where Username = '" + Convert.ToString(UsersTable.Rows[AllUsers.SelectedIndex][0]) + "'";
                try
                {
                    ConnectionToDatabase.insertData(sqlRequest);
                }
                catch
                {
                    Switcher.Switch(new FirstPage());
                }
                MessageBox.Show("Данные успешно обновлены");
                ChangeSelectedAccount.Visibility = Visibility.Collapsed;
                UpdateTable();
            }
        }

        private void ChangePhone_TextChanged(object sender, TextChangedEventArgs e)
        {
            ChangePhone.BorderBrush = Brushes.LightBlue;
            PhoneError.Text = "";
        }

        private void ChangePassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            ChangePassword.BorderBrush = Brushes.LightBlue;
            PasswordError.Text = "";
        }
    }
}
