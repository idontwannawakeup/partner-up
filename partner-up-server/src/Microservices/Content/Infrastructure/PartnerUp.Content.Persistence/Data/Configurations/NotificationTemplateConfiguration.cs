﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PartnerUp.Content.Domain.Entities;
using PartnerUp.Content.Domain.Enums;

namespace PartnerUp.Content.Persistence.Data.Configurations;

public class NotificationTemplateConfiguration : IEntityTypeConfiguration<NotificationTemplate>
{
    public void Configure(EntityTypeBuilder<NotificationTemplate> builder)
    {
        builder.HasData(
            new NotificationTemplate
            {
                Id = NotificationType.TicketAssigned,
                Title = "New ticket",
                Message = "{FullName}, you were assigned to ticket: {TicketTitle}"
            },
            new NotificationTemplate
            {
                Id = NotificationType.TicketDeadlineExpiration,
                Title = "Deadline reminder",
                Message = "{FullName}, deadline for assigned ticket is soon: {TicketTitle}, {TicketDeadline}"
            },
            new NotificationTemplate
            {
                Id = NotificationType.FriendsRequest,
                Title = "New friend",
                Message = "{FullName}, you have new friend request!"
            },
            new NotificationTemplate
            {
                Id = NotificationType.AssignedTicketDescriptionChanged,
                Title = "Ticket description changed",
                Message = "{FullName}, description of ticket changed: {TicketTitle}"
            });
    }
}
