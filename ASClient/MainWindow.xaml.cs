using DAL;
using DAL.Data;
using DAL.Entities;
using DAL.Interfaces;
using RfidReader;
using System;
using System.CodeDom;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace ASClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private RFIDSystemDbContext _rfidSystemDbContext;
        private StudentsRepository _studentsRepository;
        private Reader _reader;
        private SerialPort _rfidPort;

        public MainWindow(RFIDSystemDbContext dbContext, StudentsRepository studentsRepository)
        {
            InitializeComponent();
            _rfidSystemDbContext = dbContext;
            _studentsRepository = studentsRepository;// new(_rfidSystemDbContext);
            _rfidPort = new();
            _reader = new(_rfidPort);
            _rfidPort.DataReceived += new(Recieve);
        }

        private void Recieve(object sender, SerialDataReceivedEventArgs e)
        {
            var tag = _reader.GetRfidTag();
            Dispatcher.Invoke(new Action(() => RfidTag.Text = tag));
            var student = _studentsRepository.GetEntryByTag(tag);
            UpdateAttendance(student);
            UpdateStudentsList();
        }

        private void UpdateAttendance(Student? student)
        {
            if (student is not null)
            {
                student.Attendance = "Присутствует";
                student.AttendanceTime = DateTime.Now.ToString();
                _studentsRepository.Save(student);
            }
        }

        private void StudentsList_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateStudentsList();
        }

        private void ButtonUpdatePorts_Click(object sender, RoutedEventArgs e)
        {
            var ports = _reader.GetPortsArray;
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
                    RfidTag.Text = "";
                    _rfidPort.PortName = PortsList.Text;
                    _rfidPort.Open();
                    PortsList.IsEnabled = false;
                    ButtonUpdatePorts.IsEnabled = false;
                    ButtonConnectPort.Content = "Отключиться";
                }
                catch
                {
                    RfidTag.Text = "ОШИБКА! Не инициализирован COM-порт устройства.";
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

        private void DeleteStudent_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var student = StudentsList.SelectedItem as Student;
                _studentsRepository.Delete(student);
            }
            catch (ArgumentNullException)
            {
                RfidTag.Text = "ОШИБКА! Выберите обьект для удаления";
            }
            finally
            {
                UpdateStudentsList();
            }
        }

        private void UpdateStudentsList()
        {
            //int groupNumber = GroupsList.SelectedIndex;
            var list = _studentsRepository.GetEntries().ToList();
            Dispatcher.Invoke(new Action(() => { StudentsList.ItemsSource = list; }));
        }

        private void UpdateStudent_Click(object sender, RoutedEventArgs e)
        {
            EditWindow editWindow = new(_studentsRepository);
            editWindow.ShowDialog();
            if (!editWindow.IsActive) UpdateStudentsList();
        }

        private void EditStudent_Click(object sender, RoutedEventArgs e)
        {
            var student = StudentsList.SelectedItem as Student;
            if (student != null)
            {
                EditWindow editWindow = new(_studentsRepository, student);
                editWindow.ShowDialog();
                if (!editWindow.IsActive) UpdateStudentsList();
            }
            else
                RfidTag.Text = "ОШИБКА! Выберите обьект для изменения";
        }

        private void GroupsList_Loaded(object sender, RoutedEventArgs e)
        {
            var groups = _studentsRepository.GetEntries().ToList();
            foreach (var group in groups)
            {
                GroupsList.Items.Add(group.GroupNumber);
            }
        }
    }
}
