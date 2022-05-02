using Bootcamp.WebAPI.Events;
using MediatR;

namespace Bootcamp.WebAPI.EventHandler
{
    public class ProductCreatedSendEmailEventHandler : INotificationHandler<ProductCreatedEvent>
    {
        private readonly ILogger<ProductCreatedSendEmailEventHandler> _logger;

        public ProductCreatedSendEmailEventHandler(ILogger<ProductCreatedSendEmailEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(ProductCreatedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Email gönderildi: Ürün ID {notification.Id} - Ürün Adı {notification.Name}");
            return Task.CompletedTask;
        }
    }
}
