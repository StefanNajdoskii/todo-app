List<TodoItem> tasks = new List<TodoItem>();
DeadlineItem d = new DeadlineItem("Pay rent", "Friday");
d.MarkDone();

 Console.WriteLine(d.Title + " due " + d.DueDate + " done: " + d.IsDone);
 Console.WriteLine(d.Describe());
tasks.Add(d);

IDescribable thing = d;
Console.WriteLine(thing.Describe());
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
        break;
    }
    else
    {
        Console.WriteLine("Invalid choice, try again.");
    }
}
