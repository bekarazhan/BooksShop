using BooksShop.Models;

namespace BooksShop.ViewModels
{
    public class PublisherVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<BookVm>? Books { get; set; }
    }

}
