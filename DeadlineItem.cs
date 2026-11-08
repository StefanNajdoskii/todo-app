class DeadlineItem : TodoItem
{

public override string Describe(){ 

    return Title + " (due " + DueDate + ")"; 
    }
    public string DueDate { get; set; }

    public DeadlineItem(string title, string dueDate) : base(title)
    {
        DueDate = dueDate;
    }
}