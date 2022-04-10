using System.Collections.Generic;
using Application.Handlers;
using Application.Mediator;
using Application.Services;
using Domain.Contracts;
using Domain.Entities;
using Domain.Events;
using Infra.Repositories;
using Infra.Services;
using Xunit;

namespace tests
{
    public class SubmitQuizTest
    {
        [Fact]
        public void Test1()
        {
            // Arrange
            var repository = new QuizRepositoryMemory();
            var mailer = new MailerMemory();
            var mediator = new MyMediator();
            mediator.RegisterHandler(new List<IHandler>()
            {
                new QuizCorrectorHandler(mediator, repository),
                new QuizCommunicatorHandler(mailer)
            });

            var @event = new QuizSubmittedEvent()
            {
                Username = "Vitor",
                Email = "vitormoschetta@gmail.com",
                QuizId = 1,
                Answers = new List<Answer>()
                {
                    new Answer()
                    {
                        QuestionId = 1,
                        AnswerText = "Paris"
                    },
                    new Answer()
                    {
                        QuestionId = 2,
                        AnswerText = "Madrid"
                    }
                }
            };

            var submitQuiz = new SubmitQuiz(mediator);

            // Act
            submitQuiz.Execute(@event);

            // Assert
            Assert.Equal($"Olá {@event.Username}, sua nota do quiz é 100", mailer.messages[0].ToString());
        }
    }
}