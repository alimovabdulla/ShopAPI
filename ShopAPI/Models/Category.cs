namespace ShopAPI.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
 
        public ICollection<SubCategory> SubCategories
        {
            get; set;

        }
    }
}