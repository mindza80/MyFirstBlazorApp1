using MyFirstServerSideBlazor.Classes.Books;

namespace MyFirstServerSideBlazor.Servises.Contracts
{
    public interface IBookServise
    {
        public Task<List<Book>> SearchBooksByAuthor(string searchKeyWords);
    }
}
