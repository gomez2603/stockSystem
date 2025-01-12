﻿using StockSystem.dataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stockSystem.Repository.Interfaces
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        void Update(Product product);
    }
}