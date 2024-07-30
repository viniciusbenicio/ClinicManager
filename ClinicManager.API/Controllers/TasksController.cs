using ClinicManager.Application.Job;
using Hangfire;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManager.API.Controllers
{
    [Route("api/tasks")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly NotificationEmailTask _notificationEmailTask;
        public TasksController(NotificationEmailTask notificationEmailTask)
        {
            _notificationEmailTask = notificationEmailTask;
        }

        [HttpGet("fire-forget")]
        public IActionResult FireAndForget()
        {
            BackgroundJob.Enqueue(() => _notificationEmailTask.Execute());

            return Ok();
        }


        [HttpGet("fire-forget-continuation")]
        public IActionResult FireAndForgetWithConinuation()
        {
            var id = BackgroundJob.Enqueue(() => Console.WriteLine("Fire and Forget With Continuation"));

            BackgroundJob.ContinueJobWith(id, () => Console.WriteLine(id));

            return Ok();
        }


        [HttpGet("delayed")]
        public IActionResult Delayed()
        {
            BackgroundJob.Schedule(() => _notificationEmailTask.Execute(), TimeSpan.FromSeconds(15));
            return Ok();
        }


        [HttpGet("recurring")]
        public IActionResult Recurring()
        {

            RecurringJob.AddOrUpdate<NotificationEmailTask>("job-send-notification", jb => jb.Execute(), "*/1 * * * *");

            return Ok();
        }

        [HttpGet("cancel-recurring")]
        public IActionResult CancelRecurring(string jobId)
        {
            RecurringJob.RemoveIfExists(jobId);

            return Ok();
        }
    }
}
