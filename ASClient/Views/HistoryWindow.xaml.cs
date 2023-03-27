using DAL.Models.Entities;
using DAL.Models.Repositories;
using System.Linq;
using System.Windows;

namespace ASClient.Views
{
    /// <summary>
    /// Логика взаимодействия для HistoryWindow.xaml
    /// </summary>
    public partial class HistoryWindow : Window
    {
        private readonly AttendanceRecordsRepository _recordsRepository;
        //private readonly GroupsRepository _groupsRepository;

        public HistoryWindow(AttendanceRecordsRepository recordsRepository, GroupsRepository groupsRepository)
        {
            InitializeComponent();
            _recordsRepository = recordsRepository;
            GroupsList.ItemsSource = groupsRepository.GetGroups().ToList();
            EntriesList.ItemsSource = _recordsRepository.GetAttendanceRecords();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void GroupsList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            EntriesList.ItemsSource = _recordsRepository.GetAttendanceRecords(GroupsList.SelectedItem as Group);
        }
    }
}
