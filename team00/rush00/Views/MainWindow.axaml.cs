using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using rush00.Models;

namespace rush00.Views;

public partial class MainWindow : Window
{
    private TextBox titleTextBox;
    private TextBox motivationTextBox;
    private TextBox daysTextBox;
    
    public MainWindow()
    {
        InitializeComponent();
        titleTextBox = this.FindControl<TextBox>("TitleTextBox");
        motivationTextBox = this.FindControl<TextBox>("MotivationTextBox");
        daysTextBox = this.FindControl<TextBox>("DaysTextBox");
#if DEBUG
        this.AttachDevTools();
#endif
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public void StartButton_Click(object sender, RoutedEventArgs e)
    {
        string title = titleTextBox.Text;
        string motivation = motivationTextBox.Text;
        int days = int.Parse(daysTextBox.Text);

        DateTime startDate = DateTime.Now;
        Habit habit = new Habit(title, motivation, startDate, days);

        TrackingScreen trackingScreen = new TrackingScreen(habit);
        trackingScreen.Show();
        this.Close();
    }
}