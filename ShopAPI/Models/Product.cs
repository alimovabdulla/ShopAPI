using System.Text.Json.Serialization;

namespace ShopAPI.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string CostPrice { get; set; }
        public string SalePrice { get; set; }
        [JsonIgnore]

        public int BrandId { get; set; }
        [JsonIgnore]
        public Brand Brand { get; set; }
        
    }
}
