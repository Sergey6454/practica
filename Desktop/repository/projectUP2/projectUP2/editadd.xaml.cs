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
    /// Логика взаимодействия для editadd.xaml
    /// </summary>
    
        public partial class editadd : Window
        {
            private Service _service = new Service();
            public editadd(Service Selectedservice)
            {
                if (Selectedservice != null)
                {
                    _service = Selectedservice;
                }
                InitializeComponent();
                _service.DurationInSeconds = _service.DurationInSeconds * 60;
                DataContext = _service;

            }

            private void Button_Click(object sender, RoutedEventArgs e)
            {
                StringBuilder error = new StringBuilder();
                //if(_service.MainImagePath==null)
                //{
                //    error.AppendLine("Выберите фотографию");
                //}
                if (string.IsNullOrWhiteSpace(_service.Title))
                {
                    error.AppendLine("Укажите название услуги");
                }
                if (_service.Cost < 0)
                {
                    error.AppendLine("Цена не может быть меньше 0 руб");
                }
                if (_service.Discount < 0 || _service.Discount > 1)
                {
                    error.AppendLine("Неверный формат скидки");
                }
                if(_service.DurationInSeconds>14400||_service.DurationInSeconds<0)
            {
                error.AppendLine("Время не должно превышать 4-х часов(14400 сек) и не должно быть отрицательным");
            }
                if (error.Length > 0)
                {
                    MessageBox.Show(error.ToString());
                    return;
                }
                
                if (_service.ID == 0)
                {
                    if (_service.MainImagePath == null)
                    {
                        _service.MainImagePath = "/Услуги салона красоты/No_photo.jpg";
                    }
                    DB_beutyEntities.GetContext().Service.Add(_service);
                }


                try
                {
                    _service.DurationInSeconds = _service.DurationInSeconds / 60;
                    DB_beutyEntities.GetContext().SaveChanges();
                    MessageBox.Show("Информация успешно сохранена!");
                    AdminWindow adWindow = new AdminWindow();
                    adWindow.Show();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }

            private void Window_Loaded(object sender, RoutedEventArgs e)
            {
                //cmbimage.ItemsSource = DB_beutyEntities.GetContext().Service.ToList();
            }

            private void Button_Click_1(object sender, RoutedEventArgs e)
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
        }
    }

