﻿using SignalRApp.Models;

namespace SignalRApp.Repositories
{
    public interface IProductRepository
    {
        List<Product> GetAll();
    }
}
