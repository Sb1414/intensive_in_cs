using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace d02_ex01.Tasks
{
    internal class Task
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime? DueDate { get; private set; }
        public TaskType Type { get; private set; }
        public TaskPriority Priority { get; private set; }
        public TaskState State { get; private set; }

        public Task(string title, string description, DateTime? dueDate, TaskType type, TaskPriority priority)
        {
            Title = title;
            Description = description;
            DueDate = dueDate;
            Type = type;
            Priority = priority;
            State = TaskState.New;
        }

        public void MarkAsDone()
        {
            if (State != TaskState.Done)
                State = TaskState.Done;
        }

        public void MarkAsNotApplicable()
        {
            if (State != TaskState.Done)
                State = TaskState.NotRelevant;
        }

        public override string ToString()
        {
            string dueDateStr = DueDate.HasValue ? DueDate.Value.ToString("MM/dd/yyyy") : "";
            string priorityStr = Priority.ToString();

            string taskDetails = $"{Title}\n[{Type}] [{State}]\nPriority: {priorityStr}";
            if (!string.IsNullOrEmpty(dueDateStr))
                taskDetails += $", Due till {dueDateStr}";

            if (!string.IsNullOrEmpty(Description))
                taskDetails += $"\n{Description}";

            return taskDetails;
        }
    }
}
