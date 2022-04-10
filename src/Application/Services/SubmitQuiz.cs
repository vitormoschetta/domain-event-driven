using Application.Mediator;
using Domain.Contracts;

namespace Application.Services
{
    public class SubmitQuiz
    {
        private readonly MyMediator _mediator;

        public SubmitQuiz(MyMediator mediator)
        {
            _mediator = mediator;
        }

        public void Execute(IDomainEvent @event)
        {
            _mediator.Send(@event);
        }
    }
}