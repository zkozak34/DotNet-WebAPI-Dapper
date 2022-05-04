using Bootcamp.Service.Events;
using MediatR;

namespace Bootcamp.WebAPI.EventHandler
{
    public class ProductCreatedSendEmailEventHandler : INotificationHandler<ProductCreatedEvent>
    {


        public Task Handle(ProductCreatedEvent notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Email gönderildi: Ürün ID {notification.Id} - Ürün Adı {notification.Name}");
            return Task.CompletedTask;
        }
    }
}
