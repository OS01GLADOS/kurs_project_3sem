using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;

namespace kursProjectV3.pages
{
    public partial class RunsControl2 : UserControl, ISwitchable
    {
        DBUsers CurrentUser;
        DataTable FilLCurrentUserDirections;
        DataTable FillCurrentDirectionRuns;
        DataTable FillCurrentRunOrders;
        string carrier;

        public RunsControl2()
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

        private void ToUserCabinet(object sender, RoutedEventArgs e)
        {
            SendedObject Send = new SendedObject(CurrentUser);
            Switcher.Switch(new UserCabinet(), Send);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            string sqlRequest = "select Username from users where Userstatus = 'Carrier'";
            SqlDataAdapter adapter = ConnectionToDatabase.GetRequestResult(sqlRequest);
            DataTable Carriers = new DataTable();
            try
            {
                adapter.Fill(Carriers);
            }
            catch
            {
                Switcher.Switch(new FirstPage());
            }
            ForAdmin.Items.Clear();
            for (int i = 0; i < Carriers.Rows.Count; i++)
            {
                ForAdmin.Items.Add(Convert.ToString(Carriers.Rows[i][0]));
            }
            if (CurrentUser.UserStatusV == "Admin")
            {
                ForAdmin.Visibility = Visibility.Visible;
                ForAdminText.Visibility = Visibility.Visible;
                carrier = Convert.ToString(ForAdmin.SelectedItem);
            }
            else
            {
                ForAdminText.Visibility = Visibility.Collapsed;
                ForAdmin.Visibility = Visibility.Collapsed;
                carrier = CurrentUser.UsernameV;
            }
            LoadTable(carrier);
        }

        private void LoadTable(string carrier)
        {
            string sqlRequest = "select distinct dir.Direction, DepartingPoint, ArrivalPoint, cast(Departing as time(0))[DepartingTime], (Select Count(*) from Runs where Direction =dir.Direction)[RunsCountByDir] "+
                                "from DIRECTION dir "+
                                "where Carrier = '" + carrier + "'";
            FilLCurrentUserDirections = new DataTable();
            SqlDataAdapter adapter = ConnectionToDatabase.GetRequestResult(sqlRequest);
            try
            {
                adapter.Fill(FilLCurrentUserDirections);
            }
            catch
            {
                Switcher.Switch(new FirstPage());
            }
            if (FilLCurrentUserDirections.Rows.Count == 0)
            {
                AllDirections.Visibility = Visibility.Collapsed;
                NoDirections.Visibility = Visibility.Visible;
            }
            else
            {
                AllDirections.Visibility = Visibility.Visible;
                NoDirections.Visibility = Visibility.Collapsed;
                AllDirections.ItemsSource = FilLCurrentUserDirections.DefaultView;
            }
        }

        private void ForAdmin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            carrier = Convert.ToString(ForAdmin.SelectedItem);
            LoadTable(carrier);
        }

        private void AddDirectionButton_Click(object sender, RoutedEventArgs e)
        {
            if (DepartingPointIn.Text.Length ==0)
            {
                DepartingPointInError.Text = "Заполните это поле";
                DepartingPointIn.BorderBrush = Brushes.Red;
            }
            if (ArrivalPointIn.Text.Length == 0)
            {
                ArrivalPointInError.Text = "Заполните это поле";
                ArrivalPointIn.BorderBrush = Brushes.Red;
            }
            if (PriceIn.Text.Length == 0)
            {
                PriceInError.Text = "Заполните это поле";
                PriceIn.BorderBrush = Brushes.Red;
            }
            else
            {
                if(Regex.IsMatch(PriceIn.Text, @"\D"))
                {
                    PriceInError.Text = "В данном поле могут быть только цифры";
                    PriceIn.BorderBrush = Brushes.Red;
                }
            }
            if (CapacityIn.Text.Length == 0)
            {
                CapacityInError.Text = "Заполните это поле";
                CapacityIn.BorderBrush = Brushes.Red;
            }
            else
            {
                if (Regex.IsMatch(CapacityIn.Text, @"\D"))
                {
                    CapacityInError.Text = "В данном поле могут быть только цифры";
                    CapacityIn.BorderBrush = Brushes.Red;
                }
            }

            Regex reg = new Regex(@"^[0-2][0-9]:[0-5][0-9]$");
            if (ArrivalTime.Text.Length == 0)
            {
                ArrivalTimeInError.Text = "Заполните это поле";
                ArrivalTime.BorderBrush = Brushes.Red;
            }
            else
            {
                if (!reg.IsMatch(ArrivalTime.Text))
                {
                    MessageBox.Show(CapacityIn.Text);
                    ArrivalTimeInError.Text = "Введите время в формате чч:мм";
                    ArrivalTime.BorderBrush = Brushes.Red;
                }
            }
            if (DepartureTimeIn.Text.Length == 0)
            {
                DepartureTimeInError.Text = "Заполните это поле";
                DepartureTimeIn.BorderBrush = Brushes.Red;
            }
            else
            {
                if (!reg.IsMatch(DepartureTimeIn.Text))
                {
                    DepartureTimeInError.Text = "Введите время в формате чч:мм";
                    DepartureTimeIn.BorderBrush = Brushes.Red;
                }
            }

            if (DepartingPointInError.Text == "" && ArrivalPointInError.Text =="" && PriceInError.Text == "" && DepartureTimeInError.Text == "" && ArrivalTimeInError.Text =="" && CapacityInError.Text == "")
            {
                int DirNumber;
                if (FilLCurrentUserDirections.Rows.Count == 0)
                {
                    DirNumber = (10000 * ForAdmin.Items.Count) + 1;
                }
                else
                {
                    DirNumber = (Convert.ToInt32(FilLCurrentUserDirections.Rows[0][0]) / 10000)*10000 + FilLCurrentUserDirections.Rows.Count+1;
                }
                string sqlRequest = "insert Into DIRECTION (Direction, DepartingPoint, ArrivalPoint, Price, Departing,Arrival, Carrier, Capacity) values "+
                                    " ('"+DirNumber+"', '" + DepartingPointIn.Text + "', '"+ArrivalPointIn.Text+"', '"+PriceIn.Text+"', '"+DepartureTimeIn.Text+"', '"+ArrivalTime.Text+"', '"+ carrier + "', '"+CapacityIn.Text+"')";
                try
                {
                    ConnectionToDatabase.insertData(sqlRequest);
                }
                catch
                {
                    Switcher.Switch(new FirstPage());
                }
                MessageBox.Show("Маршрут добавлен");
                LoadTable(carrier);
                FormToAddDirection.Visibility = Visibility.Collapsed;
            }

        }

        private void DepartingPointIn_TextChanged(object sender, TextChangedEventArgs e)
        {
            DepartingPointInError.Text = "";
            DepartingPointIn.BorderBrush = Brushes.LightBlue;
        }

        private void ArrivalPointIn_TextChanged(object sender, TextChangedEventArgs e)
        {
            ArrivalPointInError.Text = "";
            ArrivalPointIn.BorderBrush = Brushes.LightBlue;
        }

        private void PriceIn_TextChanged(object sender, TextChangedEventArgs e)
        {
            PriceInError.Text = "";
            PriceIn.BorderBrush = Brushes.LightBlue;
        }

        private void DepartureTimeIn_TextChanged(object sender, TextChangedEventArgs e)
        {
            DepartureTimeInError.Text = "";
            DepartureTimeIn.BorderBrush = Brushes.LightBlue;
        }

        private void ArrivalTime_TextChanged(object sender, TextChangedEventArgs e)
        {
            ArrivalTimeInError.Text = "";
            ArrivalTime.BorderBrush = Brushes.LightBlue;
        }

        private void CapacityIn_TextChanged(object sender, TextChangedEventArgs e)
        {
            CapacityInError.Text = "";
            CapacityIn.BorderBrush = Brushes.LightBlue;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FormToAddDirection.Visibility = Visibility.Visible;
        }

        private void AllDirections_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DeleteDirection.Visibility = Visibility.Visible;
            RunsOnChosenDirectionStats.Visibility = Visibility.Visible;
            AllOrdersOnCurrentRun.Visibility = Visibility.Collapsed;
            loadRunsTable();
        }

        private void DeleteDirection_Click(object sender, RoutedEventArgs e)
        {
            if (AllDirections.SelectedIndex != -1)
            {
                string sqlRequest = "Delete DIRECTION where direction = '" + FilLCurrentUserDirections.Rows[AllDirections.SelectedIndex][0] + "'";
                try
                {
                    ConnectionToDatabase.insertData(sqlRequest);
                }
                catch
                {
                    Switcher.Switch(new FirstPage());
                }
                LoadTable(carrier);
            }
            RunsOnChosenDirectionStats.Visibility = Visibility.Collapsed;
            DeleteDirection.Visibility = Visibility.Collapsed;
        }

        private void ToUserMainPage(object sender, RoutedEventArgs e)
        {
            SendedObject Send = new SendedObject(CurrentUser);
            Switcher.Switch(new UserMainPage(), Send);
        }

        private void loadRunsTable()
        {
            string sqlRequest = "select Run , DepartureDate, (Select COUNT(*) from orders where Run =r.Run)[OrderCount], RunStatus from RUNS r where DIRECTION ='" + FilLCurrentUserDirections.Rows[AllDirections.SelectedIndex][0] + "'";
            FillCurrentDirectionRuns = new DataTable();
            try
            {
                SqlDataAdapter adapter = ConnectionToDatabase.GetRequestResult(sqlRequest);
                adapter.Fill(FillCurrentDirectionRuns);
            }
            catch
            {
                Switcher.Switch(new FirstPage());
            }
            if (FillCurrentDirectionRuns.Rows.Count !=0)
            {
                RunsOnChosenDirection.Visibility = Visibility.Visible;
                NoRuns.Visibility = Visibility.Collapsed;
                RunsOnChosenDirection.ItemsSource = FillCurrentDirectionRuns.DefaultView;
            }
            else
            {
                RunsOnChosenDirection.Visibility = Visibility.Collapsed;
                NoRuns.Visibility = Visibility.Visible;
                
            }
        }

        private void RunDepartingTime_TextChanged(object sender, TextChangedEventArgs e)
        {
            RunDepartingTime.BorderBrush = Brushes.LightBlue;
            RunDepartingTimeError.Text = "";
        }

        private void RunAvailableCapacity_TextChanged(object sender, TextChangedEventArgs e)
        {
            RunAvailableCapacity.BorderBrush = Brushes.LightBlue;
            RunAvailableCapacityError.Text = "";
        }

        private void AddRunButton_Click(object sender, RoutedEventArgs e)
        {
            Regex reg = new Regex(@"^\d{2}-\d{2}-\d{4}$");
            if (RunDepartingTime.Text.Length == 0)
            {
                RunDepartingTimeError.Text = "Заполните это поле";
                RunDepartingTime.BorderBrush = Brushes.Red;
            }
            else
            {
                if (!reg.IsMatch(RunDepartingTime.Text))
                {
                    RunDepartingTimeError.Text = "Введите дату в формате дд-мм-гггг";
                    RunDepartingTime.BorderBrush = Brushes.Red;
                }
            }

            reg = new Regex(@"\D");
            if (RunAvailableCapacity.Text.Length == 0)
            {
                RunAvailableCapacityError.Text = "Заполните это поле";
                RunAvailableCapacity.BorderBrush = Brushes.Red;
            }
            else
            {
                if (reg.IsMatch(RunAvailableCapacity.Text))
                {
                    RunAvailableCapacityError.Text = "Введено некорректное значение";
                    RunAvailableCapacity.BorderBrush = Brushes.Red;
                }
            }

            if (RunAvailableCapacityError.Text == "" && RunDepartingTimeError.Text =="")
            {
                string sqlRequest = "insert into RUNS (RUN, Direction, DepartureDate, AvailableSpace, RunStatus) values (select((select count (*) from RUNS )+1), '"+ FilLCurrentUserDirections.Rows[AllDirections.SelectedIndex][0] + "', '"+ RunDepartingTime.Text + "', '"+ RunAvailableCapacity.Text + "', 'Ordered' )";
                try
                {
                    ConnectionToDatabase.insertData(sqlRequest);
                }
                catch
                {
                    Switcher.Switch(new FirstPage());
                }
                loadRunsTable();
                AddRun.Visibility = Visibility.Collapsed;
            }
        }

        private void RunsOnChosenDirection_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if ((string)FillCurrentDirectionRuns.Rows[RunsOnChosenDirection.SelectedIndex][3] == "Ordered")
            {
                deleteRun.Visibility = Visibility.Visible;
                completeRun.Visibility = Visibility.Visible;
            }
            else
            {
                deleteRun.Visibility = Visibility.Collapsed;
                completeRun.Visibility = Visibility.Collapsed;
            }
            GetOrdersOnCurrentRun();
            //проверить не пусто ли

        }
        private void GetOrdersOnCurrentRun()
        {
            string sqlRequest = "Select Client, CargoWeight, (select PhoneNumber from Users where Username = Client)[phoneNumber] from Orders where run = '" + FillCurrentDirectionRuns.Rows[RunsOnChosenDirection.SelectedIndex][0] + "'";
            FillCurrentRunOrders = new DataTable();
            try
            {
                SqlDataAdapter adapter = ConnectionToDatabase.GetRequestResult(sqlRequest);
                adapter.Fill(FillCurrentRunOrders);
            }
            catch
            {
                Switcher.Switch(new FirstPage());
            }
            
            AllOrdersOnCurrentRun.Visibility = Visibility.Visible;
            if (FillCurrentRunOrders.Rows.Count !=0)
            {
                AllOrdersOnCurrentRunTable.ItemsSource = FillCurrentRunOrders.DefaultView;
                AllOrdersOnCurrentRunTable.Visibility = Visibility.Visible;
                AllOrdersTopic.Visibility = Visibility.Visible;
                NoOrders.Visibility = Visibility.Collapsed;

            }
            else
            {
                AllOrdersOnCurrentRunTable.Visibility = Visibility.Collapsed;
                AllOrdersTopic.Visibility = Visibility.Collapsed;
                NoOrders.Visibility = Visibility.Visible;

            }
        }

        private void DeleteRun_Click(object sender, RoutedEventArgs e)
        {
            string sqlCommand = "update RUNS set RunStatus = 'Canceled' where run = '"+ FillCurrentDirectionRuns.Rows[RunsOnChosenDirection.SelectedIndex][0] + "'";
            sqlCommand += " update Orders set OrderStatus = 'Canceled' Where run = '"+FillCurrentDirectionRuns.Rows[RunsOnChosenDirection.SelectedIndex][0]+"'";
            MessageBoxResult messsageBox = MessageBox.Show("Вы действительно хотите отменить рейс?", "Отменить рейс", MessageBoxButton.YesNo);
            if (messsageBox == MessageBoxResult.Yes)
            {
                MessageBox.Show("Рейс отменён");
                try
                {
                    ConnectionToDatabase.insertData(sqlCommand);
                }
                catch
                {
                    Switcher.Switch(new FirstPage());
                }
                deleteRun.Visibility = Visibility.Collapsed;
                completeRun.Visibility = Visibility.Collapsed;
            }
        }

        private void CompleteRun_Click(object sender, RoutedEventArgs e)
        {
            string sqlCommand = "update RUNS set RunStatus = 'Completed' where run = '" + FillCurrentDirectionRuns.Rows[RunsOnChosenDirection.SelectedIndex][0] + "'";
            sqlCommand += " update Orders set OrderStatus = 'Completed' Where run = '" + FillCurrentDirectionRuns.Rows[RunsOnChosenDirection.SelectedIndex][0] + "'";
            MessageBoxResult messsageBox = MessageBox.Show("Вы действительно хотите подтвердить прибытие рейса?", "Подтвердить прибытие рейса", MessageBoxButton.YesNo);
            if (messsageBox == MessageBoxResult.Yes)
            {
                MessageBox.Show("Прибытие рейса подтверждено");
                try
                {
                    ConnectionToDatabase.insertData(sqlCommand);
                }
                catch
                {
                    Switcher.Switch(new FirstPage());
                }
                deleteRun.Visibility = Visibility.Collapsed;
                completeRun.Visibility = Visibility.Collapsed;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AddRun.Visibility = Visibility.Visible;
        }
    }
}
