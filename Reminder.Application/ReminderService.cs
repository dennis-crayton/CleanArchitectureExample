using ReminderApp.Domain;
using ReminderApp.Infrastructure.Reminders;

namespace ReminderApp.Application;

public class ReminderService
{
    private readonly ReminderRepository _repository;
    private readonly NotificationService _notificationService;

    public ReminderService(ReminderRepository repository, NotificationService notificationService)
    {
        _repository = repository;
        _notificationService = notificationService;
    }

    public void SetReminder(string message, DateTime reminderTime)
    {
        var reminder = new Reminder
        {
            Message = message,
            ReminderTime = reminderTime,
            IsCompleted = false
        };

        _repository.Add(reminder);
    }

    public void UpdateReminder(int id, string message, DateTime reminderTime)
    {
        var reminder = _repository.GetById(id);
        if (reminder == null) return;

        reminder.Message = message;
        reminder.ReminderTime = reminderTime;

        _repository.Update(reminder);
    }

    public void DeleteReminder(int id)
    {
        _repository.Delete(id);
    }

    public void NotifyForReminder()
    {
        var dueReminders = _repository.GetDueReminders(DateTime.Now);

        foreach (var reminder in dueReminders)
        {
            _notificationService.Send(reminder);
        }
    }
}