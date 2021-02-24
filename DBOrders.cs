namespace kursProjectV3
{
   public class DBOrders
   {
        public int OrderV { get; set; }
        public double CargoWeightV { get; set; }
        public int RunV { get; set; }
        public string ClientV { get; set; }
        public string OrderStatusV { get; set; }
        public DBOrders (int RunIn, DBUsers Client)
        {
            RunV = RunIn;
            ClientV = Client.UsernameV;
            OrderStatusV = "Ordered";
        }
    }
}
