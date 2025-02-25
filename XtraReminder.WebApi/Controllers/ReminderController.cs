using Microsoft.AspNetCore.Mvc;
using XtraReminder.Shared;
using XtraReminder.WebApi.Services;

namespace XtraReminder.WebApi.Controllers;

[ApiController]
[Route("api/reminders")]
public class ReminderController(ReminderService reminderService) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<ActionResult<ReminderResponse>> Get(Guid id, CancellationToken cancellationToken)
    {
        var reminder = await reminderService.Get(id, cancellationToken);
        return Ok(reminder);
    }

    [HttpGet]
    public async Task<ActionResult<List<ReminderResponse>>> GetAll(CancellationToken cancellationToken)
    {
        var reminders = await reminderService.GetAll(cancellationToken);
        return Ok(reminders);
    }

    [HttpPost]
    public async Task<ActionResult<ReminderResponse>> Create(ReminderRequest request, CancellationToken cancellationToken)
    {
        var reminder = await reminderService.Create(request, cancellationToken);
        return CreatedAtAction(nameof(Get), new { id = reminder.Id }, reminder);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ReminderResponse>> Update(Guid id, ReminderRequest request, CancellationToken cancellationToken)
    {
        var reminder = await reminderService.Update(id, request, cancellationToken);
        return Ok(reminder);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await reminderService.Delete(id, cancellationToken);
        return NoContent();
    }
}
