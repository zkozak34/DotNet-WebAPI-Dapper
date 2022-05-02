using Bootcamp.WebAPI.Events;
using MediatR;

namespace Bootcamp.WebAPI.EventHandler
{
    public class ProductCreatedSendSmsEventHandler : INotificationHandler<ProductCreatedEvent>
    {
        private readonly ILogger<ProductCreatedSendSmsEventHandler> _logger;

        public ProductCreatedSendSmsEventHandler(ILogger<ProductCreatedSendSmsEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(ProductCreatedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"SMS Gönderildi. Ürün ID: {notification.Id} - Ürün Adı: {notification.Name}");
            return Task.CompletedTask;
        }
    }
}
