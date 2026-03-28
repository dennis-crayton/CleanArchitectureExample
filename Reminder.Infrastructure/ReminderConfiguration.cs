using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReminderApp.Domain;

namespace ReminderApp.Infrastructure.Reminders;

public sealed class ReminderConfiguration : IEntityTypeConfiguration<Reminder>
{
    public void Configure(EntityTypeBuilder<Reminder> builder)
    {
        builder.ToTable("Reminders");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Message)
            .IsRequired()
            .HasMaxLength(256);

        builder.Property(x => x.ReminderTime)
            .IsRequired();

        builder.Property(x => x.IsCompleted)
            .HasDefaultValue(false);
    }
}