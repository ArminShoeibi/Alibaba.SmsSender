namespace Alibaba.SmsSender.API.DTOs;

public record class SMSDto
{
    public string RecipientPhoneNumber { get; init; }
    public string Content { get; init; }
}
