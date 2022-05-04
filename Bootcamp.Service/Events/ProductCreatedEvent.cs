using MediatR;

namespace Bootcamp.Service.Events
{
    public class ProductCreatedEvent : INotification
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
