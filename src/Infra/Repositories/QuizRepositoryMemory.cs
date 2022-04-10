using System.Collections.Generic;
using System.Linq;
using Domain.Contracts;
using Domain.Entities;

namespace Infra.Repositories
{
    public class QuizRepositoryMemory : IQuizRepository
    {
        private readonly IList<Quiz> quizzes;
        public QuizRepositoryMemory()
        {
            quizzes = new List<Quiz>()
            {
                new Quiz
                {
                    Id = 1,
                    Name = "Quiz 1",
                    Questions = new List<Question>
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
                    }
                }
            };
        }

        public Quiz Get(int id)
        {
            return quizzes.FirstOrDefault(x => x.Id == id);
        }
    }
}