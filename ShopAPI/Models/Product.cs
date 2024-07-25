namespace ShopAPI.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string CostPrice { get; set; }
        public string SalePrice { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        
    }
}
