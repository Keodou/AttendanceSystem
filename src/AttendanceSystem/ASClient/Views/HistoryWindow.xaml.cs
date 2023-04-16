using DAL.Models.Entities;
using DAL.Models.Repositories;
using System;
using System.Collections.Generic;
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
        private readonly Schedule _schedule;
        private readonly ScheduleFiller _scheduleFiller;

        public HistoryWindow(AttendanceRecordsRepository recordsRepository, GroupsRepository groupsRepository)
        {
            InitializeComponent();
            _recordsRepository = recordsRepository;
            GroupsList.ItemsSource = groupsRepository.GetGroups().ToList();
            _schedule = new Schedule();
            _scheduleFiller = new ScheduleFiller(_schedule);
            var pairs = _scheduleFiller.GetSchedule();
            pairs.Insert(0, new Schedule()
            {
                PairNumber = "Не выбрано"
            });
            PairsList.ItemsSource = pairs;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void GroupsList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            //EntriesList.ItemsSource = _recordsRepository.GetAttendanceRecords(GroupsList.SelectedItem as Group);
        }

        private void DatesList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            DateTime date = Convert.ToDateTime(DatesList.SelectedDate);
            UpdateRecords(date, PairsList.SelectedItem as string);
        }

        /*private void UpdateRecords(DateTime date)
        {
            List<AttendanceRecord> list = _recordsRepository.GetAttendanceRecords();
            if (GroupsList.SelectedIndex > 0)
            {
                list = _recordsRepository.GetAttendanceRecords(GroupsList.SelectedItem as Group, date)
                    .DistinctBy(a => a.Student.Name).ToList();
            }
            else
            {
                list = _recordsRepository.GetAttendanceRecords(date);
            }
            EntriesList.ItemsSource = list;
        }*/

        private void UpdateRecords(DateTime date, string pair)
        {
            List<AttendanceRecord> list = _recordsRepository.GetAttendanceRecords();
            if (GroupsList.SelectedIndex > 0 && PairsList.SelectedIndex > 0)
            {
                list = _recordsRepository.GetAttendanceRecords(GroupsList.SelectedItem as Group, date, pair)
                    .DistinctBy(a => a.Student.Name).ToList();
            }
            else
            {
                list = _recordsRepository.GetAttendanceRecords(date).DistinctBy(a => a.Pair).ToList();
            }
            EntriesList.ItemsSource = list;
        }

        private void PairsList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var pair = PairsList.SelectedItem as Schedule;
            string pairStr = pair.PairNumber;
            UpdateRecords(Convert.ToDateTime(DatesList.SelectedDate), pairStr);
        }
    }
}
