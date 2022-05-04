using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace projectUP2
{
    /// <summary>
    /// Логика взаимодействия для AdminSign.xaml
    /// </summary>
    public partial class AdminSign : Window
    {
        public AdminSign()
        {
            InitializeComponent();
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (login.Password == "0000")
            {
                stringBuilder.AppendLine("Доступ разрещен!");
                AdminWindow adm = new AdminWindow();
                adm.Show();
                this.Close();
            }
            if (login.Password != "0000")
            {
                stringBuilder.AppendLine("Неверный код, попробуйте другой");

            }

        }
    }
}
