using System.Windows.Controls;

namespace kursProjectV3
{
    public static class Switcher
    {
        public static MainWindow pageSwitcher;

        public static void Switch(UserControl newPage)
        {
            pageSwitcher.Navigate(newPage);
        }

        public static void Switch (UserControl newPage, object state)
        {
            pageSwitcher.Navigate(newPage, state);
        }
    }
}
