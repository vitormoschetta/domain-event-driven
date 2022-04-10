using Domain.Entities;

namespace Domain.Contracts
{
    public interface IQuizRepository
    {
        Quiz Get(int id);
    }
}