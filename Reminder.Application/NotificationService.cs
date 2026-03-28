using ReminderApp.Domain;

namespace ReminderApp.Application;

public class NotificationService
{
    public void Send(Reminder reminder)
    {
        // Example only
        Console.WriteLine($"🔔 Reminder: {reminder.Message}");
    }
}