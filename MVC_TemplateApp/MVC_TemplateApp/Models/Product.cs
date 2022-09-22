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
    public class ProductPhoto:IEntity
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; } = null!;
        public string Url{ get; set; } = null!;
    }
}
