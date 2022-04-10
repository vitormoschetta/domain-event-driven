using System.Linq;
using Domain.Entities;
using Xunit;

namespace tests
{
    public class QuizTest
    {
        [Fact]
        public void Test1()
        {
            // Arrange
            var questions = new[]
            {
                new Question
                {
                    Id = 1,
                    Description = "What is the capital of France?",
                    Answers = new[] {"Paris", "Lyon", "Marseille", "Toulouse"},
                    CorrectAnswer = "Paris"
                },
                new Question
                {
                    Id = 2,
                    Description = "What is the capital of Spain?",
                    Answers = new[] {"Madrid", "Barcelona", "Valencia", "Seville"},
                    CorrectAnswer = "Madrid"
                }
            };

            var quiz = new Quiz
            {
                Id = 1,
                Name = "Quiz 1",
                Questions = questions
            };

            // Act


            // Assert
            Assert.True(quiz.Questions.Count() == 2);
            Assert.True(quiz.Questions.First(x => x.Id == 1).Description == "What is the capital of France?");
            Assert.True(quiz.Questions.First(x => x.Id == 1).CorrectAnswer == "Paris");
            Assert.True(quiz.Questions.First(x => x.Id == 2).Description == "What is the capital of Spain?");
            Assert.True(quiz.Questions.First(x => x.Id == 2).CorrectAnswer == "Madrid");
        }
    }
}