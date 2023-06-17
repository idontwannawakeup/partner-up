using PartnerUp.Content.Domain.Enums;

namespace PartnerUp.Content.Domain.Entities;

public class NotificationTemplate
{
    public NotificationType Id { get; set; }

    public string Title { get; set; } = default!;
    public string Message { get; set; } = default!;
}
