using Alibaba.SmsSender.API.BackgroundServices;
using Alibaba.SmsSender.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Alibaba.SmsSender.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class SMSController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> SendSMS(SMSDto smsDto, CancellationToken cancellationToken)
    {
        await SMSSenderBackgroundService.SMSChannelWriter.WriteAsync(smsDto, cancellationToken);
        return Ok();
    }
}
