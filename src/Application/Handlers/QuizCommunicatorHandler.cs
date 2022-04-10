using System;
using System.Collections.Generic;
using Domain.Contracts;
using Domain.Events;

namespace Application.Handlers
{
    public class QuizCommunicatorHandler : IHandler
    {
        private readonly IMailer _mailer;
        IList<string> IHandler.ObservedEvents
        {
            get { return new List<string> { "QuizCorrectedEvent" }; }
            set { }
        }

        public QuizCommunicatorHandler(IMailer mailer)
        {
            _mailer = mailer;
        }

        public void Handle(IDomainEvent @event)
        {
            var quizCorrectedEvent = @event as QuizCorrectedEvent;
            if (quizCorrectedEvent != null)
            {
                _mailer.Send(
                    quizCorrectedEvent.Email,
                    $"Olá {@quizCorrectedEvent.Username}, sua nota do quiz é {quizCorrectedEvent.Grade}");
            }
        }
    }
}