using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TacticalPattern.DomainEvents;

public sealed class OrderService
{
    private readonly IMediator _mediator;

    public OrderService(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task CompleteOrder()
    {
        //order işlemleri

        await _mediator.Publish(new OrderEvent(1));

        //SendEmail();
        //SendSms();
        //SendWhatsapp();
    }

    public void SendEmail()
    {
    }

    public void SendSms()
    {
    }

    public void SendWhatsapp()
    {
    }
}

public sealed class OrderEvent : INotification
{
    public int OrderId { get; }

    public OrderEvent(int orderId)
    {
        OrderId = orderId;
    }
}

public sealed class SendEmailEvent : INotificationHandler<OrderEvent>
{
    public Task Handle(OrderEvent notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

public sealed class SendSmsEvent : INotificationHandler<OrderEvent>
{
    public Task Handle(OrderEvent notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

public sealed class SendWhatsappEvent : INotificationHandler<OrderEvent>
{
    public Task Handle(OrderEvent notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}