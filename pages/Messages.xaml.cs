using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Data.SqlClient;
using System.Data;

namespace kursProjectV3.pages
{
    public partial class Messages : UserControl, ISwitchable
    {
        DBUsers CurrentUser;
        DataTable Incoming;
        DataTable Outcoming;
        bool outMessage = false;
        string Receiver;

        public Messages()
        {
            InitializeComponent();
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
            SendedObject send = new SendedObject(CurrentUser);
            Switcher.Switch(new UserMainPage(), send);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (CurrentUser.UserStatusV != "Admin")
            {
                Receiver = CurrentUser.UsernameV;
            }
            else
            {
                Receiver = "ADMIN";
            }
            FillIncomingMessages();
            FillOutcomingMessages();
        }

        private void FillIncomingMessages()
        {
            string sqlRequest = "select IDmessage, [from] , headerMessage, case when IsReaded = 0 then N'Не прочитано' else ' ' end IsReaded from ALLMESSAGERS where [to] = '" + Receiver + "'";
            Incoming = new DataTable();
            try
            {
                SqlDataAdapter adapter = ConnectionToDatabase.GetRequestResult(sqlRequest);
                adapter.Fill(Incoming);
            }
            catch
            {
                Switcher.Switch(new FirstPage());
            }
            if (Incoming.Rows.Count!=0)
            {
                NoIncoming.Visibility = Visibility.Collapsed;
                InMessages.Visibility = Visibility.Visible;
                InMessages.ItemsSource = Incoming.DefaultView;
            }
            else
            {
                NoIncoming.Visibility = Visibility.Visible;
                InMessages.Visibility = Visibility.Collapsed;
            }
        }

        private void FillOutcomingMessages()
        {
            string sqlRequest = "select IDmessage, [from] , headerMessage, case when IsReaded = 0 then N'Не прочитано' else N'Прочитано' end IsReaded from ALLMESSAGERS where [from] = '" + Receiver + "'";
            Outcoming = new DataTable();
            try
            {
                SqlDataAdapter adapter = ConnectionToDatabase.GetRequestResult(sqlRequest);
                adapter.Fill(Outcoming);
            }
            catch
            {
                Switcher.Switch(new FirstPage());
            }
            if (Outcoming.Rows.Count != 0)
            {
                NoOutcoming.Visibility = Visibility.Collapsed;
                OutMessages.Visibility = Visibility.Visible;
                OutMessages.ItemsSource = Outcoming.DefaultView;
            }
            else
            {
                NoOutcoming.Visibility = Visibility.Visible;
                OutMessages.Visibility = Visibility.Collapsed;
            }
        }

        private void ToUserCabinet(object sender, RoutedEventArgs e)
        {
            SendedObject send = new SendedObject(CurrentUser);
            Switcher.Switch(new UserCabinet(), send);
        }

        private void NewMessage_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentUser.UserStatusV == "Admin")
            {
                {
                    string sqlRequest = "select Username from users where Userstatus != 'Admin'";
                    DataTable Users = new DataTable();
                    try
                    { 
                    SqlDataAdapter adapter = ConnectionToDatabase.GetRequestResult(sqlRequest);
                    adapter.Fill(Users);
                    }
                    catch
                    {
                        Switcher.Switch(new FirstPage());
                    }
                    SelectUser.Items.Clear();
                    for (int i = 0; i < Users.Rows.Count; i++)
                    {
                        SelectUser.Items.Add(Convert.ToString(Users.Rows[i][0]));
                    }
                    SelectUser.SelectedIndex = 0;
                }
                MessageText.Height = 128;
                ChooseUsers.Visibility = Visibility.Visible;
            }
            else
            {
                MessageText.Height = 150;
                ChooseUsers.Visibility = Visibility.Collapsed;
            }
            ShowAllMessages.Visibility = Visibility.Collapsed;
            WriteNewMessage.Visibility = Visibility.Visible;
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ToMainView();
        }

        private void ToMainView()
        {
            EnterHeader.Text = "";
            MessageText.Text = "";
            ShowAllMessages.Visibility = Visibility.Visible;
            WriteNewMessage.Visibility = Visibility.Collapsed;
            ReadMessage.Visibility = Visibility.Collapsed;
        }

        private void SendMessageButtonClick (object sender, RoutedEventArgs e)
        {
            if (EnterHeader.Text.Length ==0)
            {
                EnterHeader.BorderBrush = Brushes.Red;
                EnterHeaderError.Text = "Это обязательное поле";
            }
            
            if (EnterHeaderError.Text=="")
            {
                string ToSomeone, FromSomeone;
                if (CurrentUser.UserStatusV != "Admin")
                {
                    ToSomeone = "ADMIN";
                    FromSomeone = CurrentUser.UsernameV;
                }
                else
                {
                    FromSomeone = "ADMIN";
                    ToSomeone = Convert.ToString(SelectUser.SelectedItem);
                }
                string sqlRequest = "insert into ALLMESSAGERS (IDmessage, [from], [to], headerMessage, messageMain, IsReaded) values ((select count(*) from ALLMESSAGERS)+1, '"+FromSomeone+" ', '"+ToSomeone+" ' , N'"+EnterHeader.Text+" ', N'"+ MessageText.Text + " ', 0)";
                try
                {
                    ConnectionToDatabase.insertData(sqlRequest);
                }
                catch
                {
                    Switcher.Switch(new FirstPage());
                }
                MessageBox.Show("Письмо отправлено");

                FillIncomingMessages();
                FillOutcomingMessages();
                ToMainView();
            }
        }

        private void EnterHeader_TextChanged(object sender, TextChangedEventArgs e)
        {
            EnterHeader.BorderBrush = Brushes.LightBlue;
            EnterHeaderError.Text = "";
        }

        private void InMessages_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int messageID;
            {
                messageID = Convert.ToInt32(Incoming.Rows[InMessages.SelectedIndex][0]);
                showFullMessage(messageID);
                outMessage = false;
            }
        }

        private void OutMessages_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int messageID;
            {
                messageID = Convert.ToInt32(Outcoming.Rows[OutMessages.SelectedIndex][0]);//
                outMessage = true;
                showFullMessage(messageID);
            }
        }

        private void showFullMessage(int messageID)
        {
            string sqlRequest = "Select [from], headerMessage, messageMain, [to]  from ALLMESSAGERS where IDmessage = '"+messageID+"';";
            DataTable CurrentMessage = new DataTable();
            try
            { 
            SqlDataAdapter adapter = ConnectionToDatabase.GetRequestResult(sqlRequest);
            adapter.Fill(CurrentMessage);
            }
            catch
            {
                Switcher.Switch(new FirstPage());
            }
            if (!outMessage)
                sqlRequest = "Update ALLMESSAGERS set IsReaded = 1 where IDmessage = '"+ messageID + "'";
            ConnectionToDatabase.insertData(sqlRequest);
            Sender.Text = Convert.ToString(CurrentMessage.Rows[0][0]);
            Adresee.Text = Convert.ToString(CurrentMessage.Rows[0][3]);
            Header.Text = Convert.ToString(CurrentMessage.Rows[0][1]);
            Text.Text = Convert.ToString(CurrentMessage.Rows[0][2]);
            ReadMessage.Visibility = Visibility.Visible;
            ShowAllMessages.Visibility = Visibility.Collapsed;
        }
    }
}
