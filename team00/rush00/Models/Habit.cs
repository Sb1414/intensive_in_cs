using System;
using System.Collections.Generic;

namespace rush00.Models;

public class Habit
{
	public string Title { get; }
	public string Motivation { get; }
	public DateTime StartDate { get; }
	public int TrackingDaysNumber { get; }
	public List<HabitCheck> DaysList { get; }
	public bool IsFinished { get; set; } // Add IsFinished property

	public Habit(string title, string motivation, DateTime startDate, int daysNumber)
	{
		Title = title;
		Motivation = motivation;
		StartDate = startDate;
		TrackingDaysNumber = daysNumber;
		DaysList = new List<HabitCheck>(daysNumber);
	}
}

