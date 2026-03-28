using ReminderApp.Domain;

namespace ReminderApp.Infrastructure.Reminders;

public class ReminderSeeder
{
    private readonly ReminderDbContext _dbContext;

    public ReminderSeeder(ReminderDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Seed()
    {
        if (_dbContext.Reminders.Any())
            return;

        _dbContext.Reminders.Add(new Reminder
        {
            Message = "Study for exam",
            ReminderTime = DateTime.Now.AddMinutes(15),
            IsCompleted = false
        });

        _dbContext.SaveChanges();
    }
}