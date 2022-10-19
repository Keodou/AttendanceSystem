using DAL;
using DAL.Data;
using DAL.Entities;
using DAL.Interfaces;
using RfidReader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Ports;
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

namespace ASClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string _connectionString = @"Server=DMITRYPC;Database=RFIDSystem;Trusted_Connection=True;";
        private RFIDSystemDbContext _rfidSystemDbContext;
        private StudentsRepository _studentsRepository;
        private Reader _reader;
        private SerialPort _rfidPort;

        public MainWindow()
        {
            InitializeComponent();
            _rfidSystemDbContext = new(_connectionString);
            _studentsRepository = new(_rfidSystemDbContext);
            _rfidPort = new();
            _reader = new(_rfidPort);
            _rfidPort.DataReceived += new SerialDataReceivedEventHandler(Recieve);
        }

        private void Recieve(object sender, SerialDataReceivedEventArgs e)
        {
            var tag = _reader.GetRfidTag();
            Dispatcher.Invoke(new Action(() => RfidTag.Content = tag));
            _studentsRepository.UpdateAttendance(tag);
        }

        private void StudentsList_Loaded(object sender, RoutedEventArgs e)
        {
            var list = _studentsRepository.GetEntriesDb().ToList();
            StudentsList.ItemsSource = list;
        }

        private void ButtonUpdatePorts_Click(object sender, RoutedEventArgs e)
        {
            var ports = _reader.GetPortsArray();
            PortsList.Items.Clear();
            if (ports != null)
            {
                foreach (var port in ports)
                {
                    PortsList.Items.Add(port);
                }
            }
        }

        private void ButtonConnectPort_Click(object sender, RoutedEventArgs e)
        {
            if (ButtonConnectPort.Content.ToString() == "Подключиться")
            {
                try
                {
                    _rfidPort.PortName = PortsList.Text;
                    _rfidPort.Open();
                    PortsList.IsEnabled = false;
                    ButtonUpdatePorts.IsEnabled = false;
                    ButtonConnectPort.Content = "Отключиться";
                }
                catch
                {
                    MessageBox.Show("Ошибка подключения");
                }
            }
            else if (ButtonConnectPort.Content.ToString() == "Отключиться")
            {
                _rfidPort.Close();
                ButtonUpdatePorts.IsEnabled = true;
                PortsList.IsEnabled = true;
                ButtonConnectPort.Content = "Подключиться";
            }
        }
    }
}
