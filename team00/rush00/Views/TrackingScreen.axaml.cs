using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using rush00.Models;

namespace rush00.Views;

public partial class TrackingScreen : Window
{
   private StackPanel daysStackPanel;
        private Button finishButton;
        private Habit habit;

        public TrackingScreen(Habit habit)
        {
            this.habit = habit;
            InitializeComponent();
            daysStackPanel = this.FindControl<StackPanel>("DaysStackPanel");
            finishButton = this.FindControl<Button>("FinishButton");
            PopulateDays();
        }
        
        public TrackingScreen() // Добавлен публичный конструктор без параметров
        {
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void PopulateDays()
        {
            foreach (var dayCheck in habit.DaysList)
            {
                CheckBox checkBox = new CheckBox
                {
                    Content = dayCheck.CurrentDate.ToString("dd/MM/yyyy"),
                    IsChecked = dayCheck.IsChecked
                };
                checkBox.Checked += CheckBox_Checked;
                daysStackPanel.Children.Add(checkBox);
            }
        }

        private void CheckBox_Checked(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            string dateString = checkBox.Content.ToString();
            DateTime date = DateTime.ParseExact(dateString, "dd/MM/yyyy", null);
            bool isChecked = checkBox.IsChecked.Value;
            UpdateHabitCheck(date, isChecked);
        }

        private void UpdateHabitCheck(DateTime date, bool isChecked)
        {
            foreach (var dayCheck in habit.DaysList)
            {
                if (dayCheck.CurrentDate.Date == date.Date)
                {
                    dayCheck.IsChecked = isChecked;
                    break;
                }
            }
        }

        public void FinishButton_Click(object sender, RoutedEventArgs e)
        {
            bool isFinished = true;
            foreach (var dayCheck in habit.DaysList)
            {
                if (!dayCheck.IsChecked)
                {
                    isFinished = false;
                    break;
                }
            }
            habit.IsFinished = isFinished;

            // Perform necessary actions to finish tracking

            this.Close();
        } 
}