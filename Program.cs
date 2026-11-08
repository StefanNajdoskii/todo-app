using System.Text.Json;

string filePath = "tasks.json";

List<TodoItem> tasks = new List<TodoItem>();

 if (File.Exists(filePath))
{
string json = await File.ReadAllTextAsync(filePath);
var savedTitles = JsonSerializer.Deserialize<List<string>>(json) ?? new List<string>();
foreach (string title in savedTitles)
{
tasks.Add(new TodoItem(title));
}
}

var open = tasks.Where(t => !t.IsDone).ToList();
Console.WriteLine("Open tasks: " + open.Count);

while (true)
{
    Console.WriteLine("1 = Add, 2 = Show, 3 = Remove, 4 = Done, 5 = Quit");
    string choice = Console.ReadLine();


    if (choice == "1")
    {
    Console.WriteLine("Enter a task:");
    string taskTitle = Console.ReadLine() ?? "";
    tasks.Add(new TodoItem(taskTitle));
}
else if (choice == "2")
    {
        foreach (TodoItem t in tasks)
        {
            if (t.IsDone)
            {
                Console.WriteLine("[x] " +t.Describe ());
            }
            else
            {
                Console.WriteLine("[ ] " + t.Describe());
            }
        }
    }
    else if (choice == "3")
    {
        Console.WriteLine("Which task do you want to remove?");
        string removeName = Console.ReadLine();
        TodoItem found = tasks.Find(x => x.Title == removeName);

        if (found != null)
        {
            tasks.Remove(found);
        }
        else
        {
            Console.WriteLine("Task not found.");
        }
    }
    else if (choice == "4")
    {
        Console.WriteLine("Which task do you want to mark as done?");
        string doneName = Console.ReadLine()??"";

        TodoItem doneItem = tasks.Find(x => x.Title == doneName);

        if (doneItem != null)
        {
            doneItem.MarkDone();
        }
        else
        {
            Console.WriteLine("Task not found.");
        }
    }
else if (choice == "5")
{
var titles = tasks.Select(t => t.Title).ToList();
await File.WriteAllTextAsync(filePath, JsonSerializer.Serialize(titles));
Console.WriteLine("Saved " + titles.Count + " task(s).");
break;
}
    else
    {
        Console.WriteLine("Invalid choice, try again.");
    }
}
