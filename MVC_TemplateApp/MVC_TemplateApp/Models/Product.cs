namespace MVC_TemplateApp.Models
{
    public class Product : IEntity
    {
        public Product()
        {
            ProductPhotos=new HashSet<ProductPhoto>();
        }
        public Guid Id { get ; set ; }
        public string Name { get; set; } = null!;
        public decimal StartPrice { get; set; }
        public decimal Price { get; set; }
        public int Rate { get; set; }
        public virtual ICollection<ProductPhoto> ProductPhotos { get; set; }

    }
}
