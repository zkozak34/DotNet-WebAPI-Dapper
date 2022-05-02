using MediatR;

namespace Bootcamp.WebAPI.Events
{
    public class ProductCreatedEvent : INotification
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
