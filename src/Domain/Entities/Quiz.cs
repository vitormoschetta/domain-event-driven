using System.Collections.Generic;

namespace Domain.Entities
{
    public class Quiz
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Question> Questions { get; set; }
    }
}