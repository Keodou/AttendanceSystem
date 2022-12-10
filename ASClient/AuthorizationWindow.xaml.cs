using DAL.Models.Repositories;
using Microsoft.Extensions.DependencyInjection;
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
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        private readonly UsersRepository _usersRepository;
        private readonly MainWindow _mainWindow;

        public AuthorizationWindow(UsersRepository usersRepository, MainWindow mainWindow)
        {
            InitializeComponent();
            _usersRepository = usersRepository;
            _mainWindow = mainWindow;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            if (Login.Text == "" && Password.Password == "")
            {
                Error.Text = "Вы не заполнили поля";
            }
            if (_usersRepository.GetStudents().Select(item => item.Login + " " + item.Password).Contains(Login.Text + " " + Password.Password))
            {
                _mainWindow.Show();
                Close();
            }
            else
            {
                Error.Text = "Данные некооректны";
            }
        }
    }
}
