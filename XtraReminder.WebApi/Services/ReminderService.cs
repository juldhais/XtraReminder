using Microsoft.EntityFrameworkCore;
using XtraReminder.Shared;
using XtraReminder.WebApi.Databases;
using XtraReminder.WebApi.Entities;

namespace XtraReminder.WebApi.Services;

public class ReminderService(DataContext context)
{
    public Task<ReminderResponse> Get(Guid id, CancellationToken cancellationToken)
    {
        return context.Reminders
            .Where(x => x.Id == id)
            .Select(x => new ReminderResponse 
            {
                Id = x.Id, 
                Description = x.Description, 
                Date = x.Date, 
                Priority = x.Priority, 
                IsDone = x.IsDone 
            }) .FirstAsync(cancellationToken);
    }

    public Task<List<ReminderResponse>> GetAll(CancellationToken cancellationToken)
    {
        return context.Reminders
            .Select(x => new ReminderResponse
            {
                Id = x.Id,
                Description = x.Description,
                Date = x.Date,
                Priority = x.Priority,
                IsDone = x.IsDone
            }).ToListAsync(cancellationToken);
    }

    public async Task<ReminderResponse> Create(ReminderRequest request, CancellationToken cancellationToken)
    {
        var reminder = new Reminder
        {
            Id = Guid.NewGuid(),
            Description = request.Description,
            Date = request.Date,
            Priority = request.Priority,
            IsDone = request.IsDone
        };

        context.Reminders.Add(reminder);

        await context.SaveChangesAsync(cancellationToken);

        return new() 
        { 
            Id = reminder.Id, 
            Description = reminder.Description, 
            Date = reminder.Date, 
            Priority = reminder.Priority, 
            IsDone = reminder.IsDone 
        };
    }

    public async Task<ReminderResponse> Update(Guid id, ReminderRequest request, CancellationToken cancellationToken)
    {
        var reminder = await context.Reminders
            .Where(x => x.Id == id)
            .FirstAsync(cancellationToken);

        reminder.Description = request.Description;
        reminder.Date = request.Date;
        reminder.Priority = request.Priority;
        reminder.IsDone = request.IsDone;

        await context.SaveChangesAsync(cancellationToken);

        return new()
        {
            Id = reminder.Id,
            Description = reminder.Description,
            Date = reminder.Date,
            Priority = reminder.Priority,
            IsDone = reminder.IsDone
        };
    }

    public async Task Delete(Guid id, CancellationToken cancellationToken)
    {
        var reminder = await context.Reminders
            .Where(x => x.Id == id)
            .FirstAsync(cancellationToken);

        context.Reminders.Remove(reminder);

        await context.SaveChangesAsync(cancellationToken);
    }
}
