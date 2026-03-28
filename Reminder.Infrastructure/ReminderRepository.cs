using ReminderApp.Domain;

namespace ReminderApp.Infrastructure.Reminders;

public class ReminderRepository
{
    private readonly ReminderDbContext _dbContext;

    public ReminderRepository(ReminderDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(Reminder reminder)
    {
        _dbContext.Reminders.Add(reminder);
        _dbContext.SaveChanges();
    }

    public Reminder? GetById(int id)
    {
        return _dbContext.Reminders.FirstOrDefault(r => r.Id == id);
    }

    public void Update(Reminder reminder)
    {
        _dbContext.Reminders.Update(reminder);
        _dbContext.SaveChanges();
    }

    public void Delete(int id)
    {
        var reminder = GetById(id);
        if (reminder != null)
        {
            _dbContext.Reminders.Remove(reminder);
            _dbContext.SaveChanges();
        }
    }

    public List<Reminder> GetDueReminders(DateTime currentTime)
    {
        return _dbContext.Reminders
            .Where(r => r.ReminderTime <= currentTime && !r.IsCompleted)
            .ToList();
    }
}