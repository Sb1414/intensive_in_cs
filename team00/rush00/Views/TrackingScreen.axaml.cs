using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using rush00.Models;

namespace rush00.Views;

public partial class TrackingScreen : Window
{
    private Habit habit;

    public TrackingScreen(Habit habit)
    {
        this.habit = habit;
        InitializeComponent();
    }

    public TrackingScreen()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public void FinishButton_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
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
        // TODO: Save habit or perform other actions
        this.Close();
    }
}