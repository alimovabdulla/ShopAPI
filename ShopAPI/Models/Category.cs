using System.Text.Json.Serialization;

namespace ShopAPI.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        [JsonIgnore]
        public ICollection<SubCategory> SubCategories
        {
            get; set;

        }
    }
}