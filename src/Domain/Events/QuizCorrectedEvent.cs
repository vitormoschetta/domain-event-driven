using Domain.Contracts;

namespace Domain.Events
{
    public class QuizCorrectedEvent : IDomainEvent
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public decimal Grade { get; set; }
    }
}