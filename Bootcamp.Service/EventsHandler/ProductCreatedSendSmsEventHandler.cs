using Bootcamp.Service.Events;
using MediatR;

namespace Bootcamp.Service.EventsHandler
{
    public class ProductCreatedSendSmsEventHandler : INotificationHandler<ProductCreatedEvent>
    {
        public Task Handle(ProductCreatedEvent notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"SMS Gönderildi. Ürün ID: {notification.Id} - Ürün Adı: {notification.Name}");
            return Task.CompletedTask;
        }
    }
}
