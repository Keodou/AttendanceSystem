using DAL;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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

namespace ASClient
{
    /// <summary>
    /// Логика взаимодействия для EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        private readonly StudentsRepository _studentsRepository;
        private Student? _student;
        private int _studentId;

        public EditWindow(StudentsRepository studentsRepository)
        {
            InitializeComponent();
            _studentsRepository = studentsRepository;
        }

        public EditWindow(StudentsRepository studentsRepository, Student student)
        {
            InitializeComponent();
            _studentsRepository = studentsRepository;
            _student = student;
            _studentId = _student.Id;

            studentName.Text = _student.Name;
            groupNumber.Text = _student.GroupNumber;
            rfidTag.Text = _student.RfidTag;
            attendance.Text = _student.Attendance;
            attendanceTime.Text = _student.AttendanceTime;
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            Student student = new()
            {
                Id = _studentId,
                Name = studentName.Text,
                GroupNumber = groupNumber.Text,
                RfidTag = rfidTag.Text,
                Attendance = attendance.Text,
                AttendanceTime = attendanceTime.Text,
            };

            if (student.Name == "" || student.RfidTag == "" || student.GroupNumber == "") 
                MessageBox.Show("ОШИБКА! Поля не заполнены");
            else
            {
                _studentsRepository.Save(student);
                _studentId = default;
                Close();
            }
        }
    }
}
