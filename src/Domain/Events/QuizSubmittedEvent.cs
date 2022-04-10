using System.Collections.Generic;
using Domain.Contracts;
using Domain.Entities;

namespace Domain.Events
{
    public class QuizSubmittedEvent : IDomainEvent
    {
        public int QuizId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public IList<Answer> Answers { get; set; }
    }   
}