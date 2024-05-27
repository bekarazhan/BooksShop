namespace BooksShop.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }

        public List<Author> Authors { get; set; }

        public string Source { get; set; }
    }


}
