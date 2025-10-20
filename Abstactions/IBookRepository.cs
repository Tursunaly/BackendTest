using BookStore.Models;

namespace BookStore.Abstactions
{
    public interface IBookRepository
    {
        Task<Guid> Create(Book book);
        Task<Book> GetById(Guid id);
        Task<List<Book>> Get();
        Task<Guid> Update(Guid id, string title, string description, decimal price);
    }
}
