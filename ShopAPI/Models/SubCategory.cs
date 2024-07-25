namespace ShopAPI.Models
{
    public class SubCategory:BaseEntity
    {
        public string Name { get; set; } 
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<Brand> Brands { get; set; }
       
    }
}
