using System;
using Prism.Commands;
using System.Windows.Input;
using rush00.Models;
using rush00.Views;

namespace rush00.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private string habitTitle;
        private string motivation;
        private int numberOfDays;
        private DateTime startDate;

        public string HabitTitle
        {
            get { return habitTitle; }
            set
            {
                if (habitTitle != value)
                {
                    habitTitle = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Motivation
        {
            get { return motivation; }
            set
            {
                if (motivation != value)
                {
                    motivation = value;
                    OnPropertyChanged();
                }
            }
        }

        public int NumberOfDays
        {
            get { return numberOfDays; }
            set
            {
                if (numberOfDays != value)
                {
                    numberOfDays = value;
                    OnPropertyChanged();
                }
            }
        }

        public DateTime StartDate
        {
            get { return startDate; }
            set
            {
                if (startDate != value)
                {
                    startDate = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand StartCommand { get; }

        public MainWindowViewModel()
        {
            StartCommand = new DelegateCommand(StartTracking);
        }

        private void StartTracking()
        {
            // Проверка и обработка введенных данных
            if (string.IsNullOrEmpty(HabitTitle) || string.IsNullOrEmpty(Motivation) || NumberOfDays <= 0)
            {
                return;
            }

            var habit = new Habit(HabitTitle, Motivation, StartDate, NumberOfDays);
            // Необходимо сохранить или передать habit в другую часть приложения для дальнейшего использования

            var trackingView = new TrackingScreen(habit);
            trackingView.Show();
        }
}
