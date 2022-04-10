using System;
using System.Collections.Generic;
using System.Linq;
using Application.Mediator;
using Domain.Contracts;
using Domain.Events;

namespace Application.Handlers
{
    public class QuizCorrectorHandler : IHandler
    {
        private readonly MyMediator _mediator;
        private readonly IQuizRepository _quizRepository;
        IList<string> IHandler.ObservedEvents
        {
            get { return new List<string> { "QuizSubmittedEvent" }; }
            set { }
        }

        public QuizCorrectorHandler(MyMediator mediator, IQuizRepository quizRepository)
        {
            _mediator = mediator;
            _quizRepository = quizRepository;
        }

        public void Handle(IDomainEvent @event)
        {
            Console.WriteLine(GetType().Name);

            var quizSubmittedEvent = @event as QuizSubmittedEvent;
            if (quizSubmittedEvent != null)
            {
                var quiz = _quizRepository.Get(quizSubmittedEvent.QuizId);

                var correctAnswers = 0;

                foreach (var question in quiz.Questions)
                {
                    var answer = quizSubmittedEvent.Answers.FirstOrDefault(x => x.QuestionId == question.Id);
                    if (answer.AnswerText == question.CorrectAnswer)
                    {
                        correctAnswers++;
                    }
                }

                var grade = (correctAnswers / quiz.Questions.Count) * 100;

                _mediator.Send(new QuizCorrectedEvent()
                {
                    Username = quizSubmittedEvent.Username,
                    Email = quizSubmittedEvent.Email,
                    Grade = grade
                });
            }
        }
    }
}