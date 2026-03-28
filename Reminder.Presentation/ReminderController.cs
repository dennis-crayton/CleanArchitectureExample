using Microsoft.AspNetCore.Mvc;
using ReminderApp.Application;

namespace ReminderApp.API.Controllers;

[ApiController]
[Route("api/reminders")]
public class ReminderController : ControllerBase
{
    private readonly ReminderService _service;

    public ReminderController(ReminderService service)
    {
        _service = service;
    }

    [HttpPost("set")]
    public IActionResult Set(ReminderRequest request)
    {
        _service.SetReminder(request.Message, request.ReminderTime);
        return Ok();
    }

    [HttpPut("update")]
    public IActionResult Update(ReminderUpdateRequest request)
    {
        _service.UpdateReminder(request.Id, request.Message, request.ReminderTime);
        return Ok();
    }

    [HttpDelete("delete/{id}")]
    public IActionResult Delete(int id)
    {
        _service.DeleteReminder(id);
        return Ok();
    }

    [HttpPost("notify")]
    public IActionResult Notify()
    {
        _service.NotifyForReminder();
        return Ok();
    }
}

public class ReminderRequest
{
    public string Message { get; set; } = "";
    public DateTime ReminderTime { get; set; }
}

public class ReminderUpdateRequest
{
    public int Id { get; set; }
    public string Message { get; set; } = "";
    public DateTime ReminderTime { get; set; }
}