// See https://aka.ms/new-console-template for more information

using d02_ex01.Tasks;
using System.Threading.Tasks;
using Task = d02_ex01.Tasks.Task;

List<Task> tasks = new List<Task>();

string input;

do
{
    Console.WriteLine("Enter a command (add, list, done, wontdo, quit):");
    input = Console.ReadLine();

    switch (input)
    {
        case "add":
            AddTask();
            break;
        case "list":
            ListTasks();
            break;
        case "done":
            MarkTaskAsDone();
            break;
        case "wontdo":
            MarkTaskAsNotApplicable();
            break;
        case "quit":
        case "q":
            break;
        default:
            Console.WriteLine("Invalid command. Please try again.");
            break;
    }

    Console.WriteLine();
} while (input != "quit" && input != "q");


void AddTask()
{
    Console.WriteLine("Enter a title:");
    string title = Console.ReadLine();

    Console.WriteLine("Enter a description:");
    string description = Console.ReadLine();

    Console.WriteLine("Enter the deadline (optional, leave empty if not applicable):");
    string dueDateStr = Console.ReadLine();
    DateTime? dueDate = string.IsNullOrEmpty(dueDateStr) ? null : DateTime.Parse(dueDateStr);

    Console.WriteLine("Enter the type (Work, Study, Personal):");
    string typeStr = Console.ReadLine();
    TaskType type;
    if (!Enum.TryParse(typeStr, out type))
    {
        Console.WriteLine("Input error. Check the input data and repeat the request.");
        return;
    }
    Console.WriteLine("Assign the priority (Low, Normal, High):");
    string priorityStr = Console.ReadLine();
    TaskPriority priority;
    if (!Enum.TryParse(priorityStr, out priority))
    {
        Console.WriteLine("Input error. Check the input data and repeat the request.");
        return;
    }

    Task task = new Task(title, description, dueDate, type, priority);
    tasks.Add(task);
    Console.WriteLine("Task added.");
}

void ListTasks()
{
    if (tasks.Count == 0)
    {
        Console.WriteLine("The task list is still empty.");
    }
    else
    {
        foreach (var task in tasks)
        {
            Console.WriteLine(task.ToString());
            Console.WriteLine();
        }
    }
}

void MarkTaskAsDone()
{
    Console.WriteLine("Enter a title:");
    string title = Console.ReadLine();

    Task task = FindTaskByTitle(title);
    if (task == null)
    {
        Console.WriteLine("Input error. Check the input data and repeat the request.");
        return;
    }

    task.MarkAsDone();
    Console.WriteLine($"The task [{task.Title}] is completed!");
}

void MarkTaskAsNotApplicable()
{
    Console.WriteLine("Enter a title:");
    string title = Console.ReadLine();

    Task task = FindTaskByTitle(title);
    if (task == null)
    {
        Console.WriteLine("Input error. Check the input data and repeat the request.");
        return;
    }

    task.MarkAsNotApplicable();
    Console.WriteLine($"The task [{task.Title}] is no longer relevant!");
}

Task FindTaskByTitle(string title)
{
    return tasks.Find(t => t.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
}