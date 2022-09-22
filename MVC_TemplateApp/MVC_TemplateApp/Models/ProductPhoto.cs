﻿namespace MVC_TemplateApp.Models
{
    public class ProductPhoto:IEntity
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Product? Product { get; set; }
        public string Url{ get; set; } = null!;
    }
}
