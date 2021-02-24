using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Data;
using System.Data.SqlClient;

namespace kursProjectV3.pages
{
    public partial class EnterPage : UserControl, ISwitchable
    {
        public EnterPage()
        {
            InitializeComponent();
        }

        #region ISwitchable Members
        public void UtilizeState(object state)
        {
            throw new NotImplementedException();
        }
        #endregion

        private void PreviousPage(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new FirstPage());
        }

        private void Enter(object sender, RoutedEventArgs e)
        {
            if (UsernameEntered.Text.Length == 0)
            {
                UsernameEntered.BorderBrush = Brushes.Red;
                UsernameError.Text = "Заполните это поле";
            }
            if (PasswordEntered.Password.Length == 0)
            {
                PasswordEntered.BorderBrush = Brushes.Red;
                passwordError.Text = "Заполните это поле";
            }
            
            if (UsernameError.Text == "" && passwordError.Text =="")
            {
                string sqlCommand = "select UserPassword from Users where Username = '" + UsernameEntered.Text + "'";
                SqlDataAdapter adapter = ConnectionToDatabase.GetRequestResult(sqlCommand);
                DataTable ThisUser = new DataTable();
                DataTable ThisUserFound = new DataTable();
                try
                {
                    adapter.Fill(ThisUser);
                }
                catch (Exception ex)
                {
                    Switcher.Switch(new pages.FirstPage());
                }
                if (ThisUser.Rows.Count == 0)
                {
                    UsernameEntered.BorderBrush = Brushes.Red;
                    UsernameError.Text = "Пользователь не найден, проверьте введённые данные";
                }
                else
                {
                    if (Convert.ToString(ThisUser.Rows[0][0]) != PasswordEntered.Password)
                    {
                        PasswordEntered.BorderBrush = Brushes.Red;
                        passwordError.Text = "Неверный пароль";
                    }
                    else
                    {
                        sqlCommand = "select * from Users where Username = '" + UsernameEntered.Text + "'";
                        adapter = ConnectionToDatabase.GetRequestResult(sqlCommand);
                        adapter.Fill(ThisUserFound);
                        DBUsers EnteredUser = new DBUsers((string)ThisUserFound.Rows[0][0], (string)ThisUserFound.Rows[0][1], (long)ThisUserFound.Rows[0][3], (string)ThisUserFound.Rows[0][2], (DateTime)ThisUserFound.Rows[0][4], (int)ThisUserFound.Rows[0][5]);
                        SendedObject Send = new SendedObject(EnteredUser);
                        Switcher.Switch(new UserMainPage(), Send);
                    }
                }
            }
        }

        private void UsernameEntered_TextChanged(object sender, TextChangedEventArgs e)
        {
            UsernameEntered.BorderBrush = Brushes.LightBlue;
            UsernameError.Text = "";
        }

        private void PasswordEntered_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordEntered.BorderBrush = Brushes.LightBlue;
            passwordError.Text = "";
        }
    }
}
