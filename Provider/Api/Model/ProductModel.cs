namespace Provider.Model
{
    public class ProductModel
    {
        public long Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
    }
}