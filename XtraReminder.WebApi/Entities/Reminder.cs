namespace XtraReminder.WebApi.Entities;

public class Reminder
{
    public Guid Id { get; set; }
    public string? Description { get; set; }
    public DateTime? Date { get; set; }
    public string? Priority { get; set; } // Low, Medium, High
    public bool IsDone { get; set; }
}
