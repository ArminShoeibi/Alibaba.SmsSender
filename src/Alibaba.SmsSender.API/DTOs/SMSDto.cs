namespace Alibaba.SmsSender.API.DTOs;

public record class SMSDto
{
    public string RecipientPhoneNumber { get; set; }
    public string Content { get; set; }
}
