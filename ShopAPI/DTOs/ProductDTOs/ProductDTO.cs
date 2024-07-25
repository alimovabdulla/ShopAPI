using ShopAPI.Models;

namespace ShopAPI.DTOs.ProductDTOs
{
    public class ProductDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string CostPrice { get; set; }
        public string SalePrice { get; set; }
        public int BrandId { get; set; }
    

    }
}
