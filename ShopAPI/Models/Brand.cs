using System.Text.Json.Serialization;

namespace ShopAPI.Models
{
    public class Brand : BaseEntity
    {
 
        public string Name { get; set; }
        
        public int SubCategoryId { get; set; }
        [JsonIgnore]
        public SubCategory SubCategory { get; set; }
        
        
        public ICollection<Product> Products { get; set; }

    }
}
