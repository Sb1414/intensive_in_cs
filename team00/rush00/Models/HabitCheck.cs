using System;

namespace rush00.Models;

public class HabitCheck
{
	public DateTime CurrentDate {get; }
	public bool IsChecked {get; set; }
	public bool IsFinished {get;  }

	public HabitCheck(DateTime currentDate, bool isChecked)
	{
		CurrentDate = currentDate;
		IsChecked = isChecked;
		IsFinished = false;
	}
}
