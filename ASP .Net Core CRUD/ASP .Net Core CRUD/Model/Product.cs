using System.ComponentModel.DataAnnotations;

namespace ASP_.Net_Core_CRUD.Model
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public required string ProductName { get; set; }
        public required string ProductPrice { get; set; }
        public required int Price { get; set; }
        public required string ProductDescription { get; set; }
        public int? Rating { get; set; }
        public bool Satus { get; set; }

    }
}
