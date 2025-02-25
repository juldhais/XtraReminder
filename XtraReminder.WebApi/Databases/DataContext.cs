using Microsoft.EntityFrameworkCore;
using XtraReminder.WebApi.Entities;

namespace XtraReminder.WebApi.Databases;

public class DataContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Reminder> Reminders { get; set; }
}
