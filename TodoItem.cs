class TodoItem
{
public string Title { get; set; }
public bool IsDone { get; private set; }

public virtual string Describe() { return Title; }

public TodoItem(string title)
{
Title = title;
IsDone = false;
}

public void MarkDone()
{
IsDone = true;
}
}