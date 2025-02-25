namespace XtraReminder.Shared;

public class ReminderResponse
{
    public Guid Id { get; set; }
    public string? Description { get; set; }
    public DateTime? Date { get; set; }
    public string? Priority { get; set; }
    public bool IsDone { get; set; }
}
