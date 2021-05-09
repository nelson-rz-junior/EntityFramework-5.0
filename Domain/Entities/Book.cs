namespace EntityFramework5.Domain.Entities
{
    public class Book
    {
        public int Id { get; set; }

        public int AuthorId { get; set; }

        public string Title { get; set; }

        public int ReleaseYear { get; set; }

        public virtual Author Author { get; set; }
    }
}
