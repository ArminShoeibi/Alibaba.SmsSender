namespace Alibaba.SmsSender.API.Models;

public record class SMSDto
{
    public string RecipientPhoneNumber { get; set; }
    public string Content { get; set; }
}
