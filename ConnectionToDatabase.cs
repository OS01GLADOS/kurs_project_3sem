using System;
using System.Data.SqlClient;
using System.Configuration;

namespace kursProjectV3
{
    public static class ConnectionToDatabase
    {
        private static SqlConnection _ConnectionInstance;
        private static string connectionString = ConfigurationManager.ConnectionStrings["GlobalConnection"].ConnectionString;

        public static SqlConnection GetInstanse()
        {
            if (_ConnectionInstance != null)
                return _ConnectionInstance;
            else
            {
                _ConnectionInstance = new SqlConnection(connectionString);
                return _ConnectionInstance;
            }
        }

        public static SqlDataAdapter GetRequestResult(string Request)
        {
            SqlConnection connection = null;
            SqlCommand command;

            SqlDataAdapter adapter = null;
            try
            {
                connection = GetInstanse();
                command = new SqlCommand(Request, connection);
                adapter = new SqlDataAdapter(command);
                connection.Open();
            } 

            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Не удалось подключиться к базе данных, проверьте подключение к интернету. Вы будете перенаправлены на начальную страницу");
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }

            return adapter;
        }
        public static int insertData (string request)
        {
            SqlConnection connection = GetInstanse();
            SqlCommand command = new SqlCommand(request, connection);

            
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                return 0;
            }
            catch (SqlException ex)
            {
                System.Windows.MessageBox.Show("Не удалось подключиться к базе данных, проверьте подключение к интернету. Вы будете перенаправлены на начальную страницу");
                return 1;
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }
    }
}
