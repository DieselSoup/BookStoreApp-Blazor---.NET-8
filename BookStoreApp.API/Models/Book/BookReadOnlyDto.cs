namespace BookStoreApp.API.Models.Book
{
    public class BookReadOnlyDto:BaseDto
    {
        public string Title { get; set; } = null!;

        public int? Year { get; set; }

        public string Image { get; set; } = null!;

        public double? Price { get; set; }

        public int? AuthorId { get; set; }

        public string AuthorName { get; set; }
    }
}
