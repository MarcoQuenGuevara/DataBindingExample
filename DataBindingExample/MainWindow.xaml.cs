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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
namespace DataBindingExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    class EventModel : INotifyPropertyChanged
    {
        private string title;
        private DateTime date;

        public string Title
        {
            get => title;
            set
            {
                if (value != title)
                {
                    title = value;
                    OnPropertyChanged("Title");
                }
            }

        }

        public DateTime Date
        {
            get => date;
            set
            {
                if (value != date)
                {
                    date = value;
                    OnPropertyChanged("Date");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    public partial class MainWindow : Window
    {
        private EventModel evento;
        public MainWindow()
        {
            InitializeComponent();
            evento = new EventModel()
            {
                Title = "reunion de trabajo",
                Date = new DateTime(2020, 10, 23)
            };
            //nombreTextBox.Text = evento.Title;
            //fechaDatePicker.SelectedDate = evento.Date;
            DataContext = evento;
        }

        private void ModificarEventoButton_Click(object sender, RoutedEventArgs e)
        {
            evento.Title = evento.Title.ToLower();
            evento.Date = evento.Date.AddDays(1);
            //nombreTextBox.Text = evento.Title;
            //fechaDatePicker.SelectedDate = evento.Date;
            MessageBox.Show(evento.Title + "\n" + evento.Date);
        }
    }
}
