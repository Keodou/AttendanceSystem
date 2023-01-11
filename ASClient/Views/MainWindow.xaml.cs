using ASClient.Views;
using DAL;
using DAL.Entities;
using DAL.Models.Entities;
using DAL.Models.Repositories;
using RfidReader;
using System;
using System.IO.Ports;
using System.Linq;
using System.Windows;

namespace ASClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private StudentsRepository _studentsRepository;
        private AttendanceRecordsRepository _recordsRepository;
        private GroupsRepository _groupsRepository;
        private Reader _reader;
        private SerialPort _rfidPort;

        public MainWindow(StudentsRepository studentsRepository, AttendanceRecordsRepository recordsRepository, GroupsRepository groupsRepository)
        {
            InitializeComponent();
            _studentsRepository = studentsRepository;
            _recordsRepository = recordsRepository;
            _groupsRepository = groupsRepository;
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

        private void UpdateAttendance(Student student)
        {
            if (student is not null)
            {
                student.Attendance = "Присутствует";
                student.AttendanceTime = DateTime.Now.ToString();
                _studentsRepository.Save(student);

                var attendanceRecord = new AttendanceRecord()
                {
                    Attendance = student.Attendance,
                    AttendanceTime = student.AttendanceTime,
                    StudentId = student.Id
                };
                _recordsRepository.Save(attendanceRecord);
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
            //string? groupNumber = "";
            //Dispatcher.Invoke(new Action(() => { groupNumber = GroupsList.SelectedItem as string; }));
            ///*if (groupNumber is null)
            //{
            //    var list = _studentsRepository.GetEntries().ToList();
            //    Dispatcher.Invoke(new Action(() => { StudentsList.ItemsSource = list; }));
            //}*/

            //var list = _studentsRepository.GetEntries(groupNumber).ToList();
            //Dispatcher.Invoke(new Action(() => { StudentsList.ItemsSource = list; }));
            StudentsList.ItemsSource = _studentsRepository.GetEntries(GroupsList.SelectedItem as Group).ToList();
            //StudentsList.ItemsSource = _studentsRepository.GetEntries().ToList();
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
            GroupsList.ItemsSource = _groupsRepository.GetGroups().ToList();
                
            //    .GetEntries().AsEnumerable().DistinctBy(g => g.GroupNumber).ToList();
            //foreach (var group in groups)
            //{
            //    GroupsList.Items.Add(group.GroupNumber);
            //}
        }

        private void GroupsList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            //var groupNumber = GroupsList.SelectedItem as string;
            //var list = _studentsRepository.GetEntries(groupNumber).ToList();
            //Dispatcher.Invoke(new Action(() => { StudentsList.ItemsSource = list; }));
            UpdateStudentsList();
        }

        private void StudentsList_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var student = StudentsList.SelectedItem as Student;
            if (student != null)
            {
                student = _studentsRepository.GetEntryByAttendanceRecords(student.Id).FirstOrDefault();
                var detailsWindow = new DetailsWindow(student, _studentsRepository);
                detailsWindow.ShowDialog();
            }
            else
                RfidTag.Text = "ОШИБКА! Выберите студента для просмотра его истории посещаемости";
        }
    }
}
