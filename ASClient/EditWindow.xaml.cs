using DAL;
using DAL.Entities;
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

namespace ASClient
{
    /// <summary>
    /// Логика взаимодействия для EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        private readonly StudentsRepository _studentsRepository;

        public EditWindow(StudentsRepository studentsRepository)
        {
            InitializeComponent();
            _studentsRepository = studentsRepository;
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            Student student = new()
            {
                Name = studentName.Text,
                RfidTag = rfidTag.Text,
                Attendance = attendance.Text,
                AttendanceTime = attendanceTime.Text,
            };

            if (student.Name == "" || student.RfidTag == "") 
            {
                MessageBox.Show("ОШИБКА! Поля не заполнены");
            }
            else
            {
                _studentsRepository.SaveChanges(student);
                Close();
            }
        }
    }
}
