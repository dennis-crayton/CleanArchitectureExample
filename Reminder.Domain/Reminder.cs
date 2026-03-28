namespace ReminderApp.Domain;

public class Reminder
{
    public int Id { get; set; }
    public string Message { get; set; } = "";
    public DateTime ReminderTime { get; set; }
    public bool IsCompleted { get; set; }
}