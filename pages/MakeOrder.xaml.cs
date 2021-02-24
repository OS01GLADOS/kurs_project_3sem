using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;

namespace kursProjectV3.pages
{
    public partial class MakeOrder : UserControl, ISwitchable
    {
        DBUsers CurrentUser;
        DBOrders NewOrder;
        DataTable OrderInfo = new DataTable();

        public MakeOrder()
        {
            InitializeComponent();
        }

        #region ISwitchable Members
        public void UtilizeState(object state)
        {
            SendedObject InData = state as SendedObject;
            CurrentUser = InData.SendedUser;
            NewOrder = InData.Data as DBOrders;
            getOrderInfo();
            Direction.Text = Direction.Text + " "+ OrderInfo.Rows[0][0]+" - "+ OrderInfo.Rows[0][1];
            DepartureDate.Text = DepartureDate.Text + " " + Convert.ToDateTime(OrderInfo.Rows[0][2]).ToLongDateString();
            DepartureTime.Text = DepartureTime.Text + " " + OrderInfo.Rows[0][3];
            ArrivalTime.Text = ArrivalTime.Text + " " + OrderInfo.Rows[0][4];
            NewOrder.OrderV = Convert.ToInt32(OrderInfo.Rows[0][5]) +1;
        }
        #endregion

        private void getOrderInfo()
        {
            string SqlRequest = "select DepartingPoint, ArrivalPoint, cast (DepartureDate as date) [DepartureDate], cast(Departing as time(0))[DepartingTime],cast(Arrival as time(0))[ArrivalTime], (select Count (*) from ORDERS)[OrderAmount], Price, case when r.AvailableSpace is NULL or (select sum (CargoWeight) from Orders where Run = r.Run) is null then 0 else (r.AvailableSpace -(select sum (CargoWeight) from Orders where Run = r.Run)) end SpaceAvailable " +
            "from DIRECTION inner join Runs r on r.Direction = DIRECTION.Direction where Run = " + NewOrder.RunV;
            SqlDataAdapter adapter = ConnectionToDatabase.GetRequestResult(SqlRequest);
            adapter.Fill(OrderInfo);
        }

        private void ToFindDirection(object sender, RoutedEventArgs e)
        {
            ToFindDirection();
        }

        private void ToFindDirection()
        {
            SendedObject Send = new SendedObject(CurrentUser);
            Switcher.Switch(new FindDirection(), Send);
        }

        private void ToUserCabinet(object sender, RoutedEventArgs e)
        {
            SendedObject Send = new SendedObject(CurrentUser);
            Switcher.Switch(new UserCabinet(), Send);
        }

        private void ToMakeOrder(object sender, RoutedEventArgs e)
        {
            if (EnterWeight.Text.Length == 0)
            {
                EnterError.Text = "Заполните это поле";
                EnterWeight.BorderBrush = Brushes.Red;
            }
            else
            { 
                if (Regex.IsMatch(EnterWeight.Text, @"\D"))
                {
                    EnterError.Text = "Введены некорректные данные";
                    EnterWeight.BorderBrush = Brushes.Red;
                }
                else 
                {
                    if (Convert.ToInt32(OrderInfo.Rows[0][7]) ==0 )
                    {
                        EnterError.Text = "Введённая масса не может быть перевезена этим перевозчиком";
                        EnterWeight.BorderBrush = Brushes.Red;
                    }
                    else if (Convert.ToInt32(EnterWeight.Text) > Convert.ToInt32(OrderInfo.Rows[0][7]))
                    {
                        EnterError.Text = "Введённая масса не может быть перевезена этим перевозчиком";
                        EnterWeight.BorderBrush = Brushes.Red;
                    }
                }
            }
            if(EnterError.Text == "")
            {
                MessageBoxResult messageBox = MessageBox.Show("Вы действительно хотите оформить заказ?", "Подтвердите действие", MessageBoxButton.YesNo);
                if(messageBox == MessageBoxResult.Yes)
                {
                    string sqlRequest = "insert into Orders ([Order], CargoWeight, Run, Client, OrderStatus) values " +
                                        "('" + NewOrder.OrderV + "', '" + EnterWeight.Text + "', '" + NewOrder.RunV + "', '" + NewOrder.ClientV + "', '" + NewOrder.OrderStatusV + "')" ;
                    ConnectionToDatabase.insertData(sqlRequest);
                    MessageBox.Show("Заказ оформлен успешно");
                    ToFindDirection();
                }
            }
        }

        private void EnterWeight_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (EnterWeight.Text != "" && !Regex.IsMatch(EnterWeight.Text, @"\D"))
                WeightOut.Text = "Стоимость заказа: " + Convert.ToString(Convert.ToInt32(EnterWeight.Text) * Convert.ToInt32(OrderInfo.Rows[0][6])) + "  р. Максимальная масса груза:  "+ OrderInfo.Rows[0][7];
            else
                WeightOut.Text = "Стоимость заказа: 0р.";
            EnterError.Text = "";
            EnterWeight.BorderBrush = Brushes.LightBlue;
        }
    }
}
