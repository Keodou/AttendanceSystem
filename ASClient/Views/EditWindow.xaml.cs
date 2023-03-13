using DAL;
using DAL.Entities;
using DAL.Models.Repositories;
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
        private Student? _student = new();

        public EditWindow(StudentsRepository studentsRepository, GroupsRepository groupsRepository, Student student)
        {
            InitializeComponent();
            if (student != null)
                _student = student;
            DataContext = _student;
            _studentsRepository = studentsRepository;
            groupNumber.ItemsSource = groupsRepository.GetGroups().ToList();
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            if (_student.Name == "" || _student.RfidTag == "" || _student.Group == null)
                MessageBox.Show("ОШИБКА! Поля не заполнены");

            _studentsRepository.Save(_student);
            Close();
        }
    }
}
