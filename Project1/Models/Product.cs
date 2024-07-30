namespace Project1.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Img { get; set; }
        public double Price { get; set; }
        public int Rate { get; set; }

        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}
