using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Data.SqlClient;
using System.Data;

namespace kursProjectV3.pages
{
    public partial class FindDirection : UserControl, ISwitchable
    {
        DBUsers CurrentUser;
        DataTable DirectionsTable;
        public FindDirection()
        {
            InitializeComponent();
        }

        #region ISwitchable Members
        public void UtilizeState(object state)
        {
            SendedObject InData = state as SendedObject;
            CurrentUser = InData.SendedUser;
            HowToSort.Items.Add("Времени в пути");
            HowToSort.Items.Add( "Цене за 1 кг");
            Order.Items.Add("По возрастанию");
            Order.Items.Add("По убыванию");
        }
        #endregion

        private void ToUserMainPage(object sender, RoutedEventArgs e)
        {
            SendedObject send = new SendedObject(CurrentUser);
            Switcher.Switch(new UserMainPage(), send);
        }

        private void ToUserCabinet(object sender, RoutedEventArgs e)
        {
            SendedObject send = new SendedObject(CurrentUser);
            Switcher.Switch(new UserCabinet(), send);
        }

        private void OnPageLoaded(object sender, RoutedEventArgs e)
        {
            LoadTable();
        }

        private void LoadTable()
        {
            string SqlRequest = "select direction.Direction[DirectionKey], Run[RunKey], DepartingPoint, ArrivalPoint, cast(Departing as time(0))[DepartingTime],cast(Arrival as time(0))[ArrivalTime], Round((cast(datediff(minute, Departing, Arrival) as float(2)) / 60), 2)[TimeToReach],Price, cast (DepartureDate as date) [DepartureDate], Carrier, Ranking " +
                                " from DIRECTION inner join Runs on RUNS.Direction = DIRECTION.Direction " +
                                "inner join USERS on DIRECTION.Carrier = USERS.Username ";
            if(FromPoint.Text != "" || ToPoint.Text!="")
                SqlRequest += "where ";
            if (FromPoint.Text != "")
            {
                SqlRequest += "(DepartingPoint = N'" + FromPoint.Text + "')";
                if (ToPoint.Text != "")
                    SqlRequest += " and ";
            }
            if (ToPoint.Text != "")
                SqlRequest += "(ArrivalPoint = N'"+ToPoint.Text+"')";
            SqlRequest += " Order by ";
            if (HowToSort.SelectedIndex ==0)
            {
                SqlRequest += " TimeToReach";
            }
            else
            {
                SqlRequest += " Price";
            }
            if(Order.SelectedIndex ==1)
            {
                SqlRequest += " Desc";
            }
            DirectionsTable = new DataTable();
            try
            {
                SqlDataAdapter Adapter = ConnectionToDatabase.GetRequestResult(SqlRequest);
                Adapter.Fill(DirectionsTable);
            }
            catch
            {
                Switcher.Switch(new FirstPage());
            }
            if (DirectionsTable.Rows.Count == 0)
            {
                AllDirections.Visibility = System.Windows.Visibility.Collapsed;
                Tip.Text = "Поиск не дал результатов.";
            }
            else
            {
                AllDirections.Visibility = System.Windows.Visibility.Visible;
                Tip.Text = "Нажмите на результат, для бронирования места";
                AllDirections.ItemsSource = DirectionsTable.DefaultView;
            }
        }

        private void HowToSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadTable();
        }

        private void Order_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadTable();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LoadTable();
        }

        private void AllDirections_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DBOrders NewOrder = new DBOrders(Convert.ToInt32(DirectionsTable.Rows[AllDirections.SelectedIndex][1]), CurrentUser);
            SendedObject Send = new SendedObject(CurrentUser, NewOrder as object);
            Switcher.Switch(new MakeOrder(), Send);
        }
    }
}
