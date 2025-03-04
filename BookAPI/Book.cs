namespace BookAPI
{
    public class Book
    {
        public Book(int id, string name, string description, string author, decimal price)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.Author = author;
            this.Price = price;
        }
        public Book() { }
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? Author { get; set; }
        public Decimal? Price { get; set; }
    }
}