using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace kursProjectV3.pages
{
    public partial class Registration : UserControl, ISwitchable
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void Return(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new FirstPage());
        }

        private void Register(object sender, RoutedEventArgs e)
        {
            string sqlRequest = "select Username from Users where Username = '"+UsernameEntered.Text+"'";
            DataTable Usernames = new DataTable();
            try
            { 
            if (UsernameEntered.Text.Length == 0)
            {
                usernameError.Text = "Заполните это поле";
                UsernameEntered.BorderBrush = Brushes.Red;
            }
            else
            {
                if(Regex.IsMatch(UsernameEntered.Text, @"\W"))
                {
                    usernameError.Text = "Имя пользователя должно состоять из чисел и букв";
                    UsernameEntered.BorderBrush = Brushes.Red;
                }
                else
                {
                    SqlDataAdapter adapter = ConnectionToDatabase.GetRequestResult(sqlRequest);
                    adapter.Fill(Usernames);
                    if (Usernames.Rows.Count != 0)
                    {
                        usernameError.Text = "Имя пользователя занято";
                        UsernameEntered.BorderBrush = Brushes.Red;
                    }
                }
            }
            if (PasswordEntered1.Password.Length == 0)
            {
                password1Error.Text = "Заполните это поле";
                PasswordEntered1.BorderBrush = Brushes.Red;
            }
            else
            {
                if(PasswordEntered1.Password.Length <4)
                {
                    password1Error.Text = "Пароль слишком короткий (минимум 4 символа)";
                    PasswordEntered1.BorderBrush = Brushes.Red;
                }               
            }
            if (PasswordEntered2.Password.Length ==0)
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
            if (PhoneNumber.Text.Length == 0)
            {
                phoneError.Text = "Заполните это поле";
                PhoneNumber.BorderBrush = Brushes.Red;
            }
            else
            {
                if (PhoneNumber.Text.Length <12 || Regex.IsMatch(PhoneNumber.Text,@"\D"))
                {
                    phoneError.Text = "Введите корректный номер мобильного телефона, начиная с цифры";
                    PhoneNumber.BorderBrush = Brushes.Red;
                }                
            }
            
                if (usernameError.Text == "" && password1Error.Text == "" && password2Error.Text == "" && phoneError.Text == "")
                {
                    DBUsers CurrentUser = new DBUsers(UsernameEntered.Text, PasswordEntered1.Password, Convert.ToInt64(PhoneNumber.Text));

                    sqlRequest = "insert into " +
                                 "USERS (Username, UserPassword,  PhoneNumber, RegistrationDate, Ranking) " +
                                 "values ('" + CurrentUser.UsernameV + "', '" + CurrentUser.UserPasswordV + "', '" + CurrentUser.PhoneNumberV + "', '" + CurrentUser.RegistrarionDateV.Year + "-" + CurrentUser.RegistrarionDateV.Month + "-" + CurrentUser.RegistrarionDateV.Day + "', '" + CurrentUser.RankingV + "')";
                    int i = ConnectionToDatabase.insertData(sqlRequest);
                    if (i == 0)
                    {
                        SendedObject send = new SendedObject(CurrentUser);
                        Switcher.Switch(new UserMainPage(), send);
                    }

                }
            }
            catch
            {
                Switcher.Switch(new FirstPage());
            }
        }

        #region ISwitchable Members
        public void UtilizeState(object state)
        {
            throw new NotImplementedException();
        }
        #endregion

        private void UsernameEntered_TextChanged(object sender, TextChangedEventArgs e)
        {
            usernameError.Text = null;
            UsernameEntered.BorderBrush = Brushes.LightBlue;
        }

        private void PasswordEntered1_PasswordChanged(object sender, RoutedEventArgs e)
        {
            password1Error.Text = null;
            PasswordEntered1.BorderBrush = Brushes.LightBlue;
        }

        private void PasswordEntered2_PasswordChanged(object sender, RoutedEventArgs e)
        {
            password2Error.Text = null;
            PasswordEntered2.BorderBrush = Brushes.LightBlue;
        }

        private void PhoneNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            PhoneNumber.BorderBrush = Brushes.LightBlue;
            phoneError.Text = null;
        }
    }
}
