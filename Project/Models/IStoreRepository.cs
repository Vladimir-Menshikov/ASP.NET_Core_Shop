﻿using System.Linq;
namespace Project.Models
{
    public interface IStoreRepository
    {
        IQueryable<Product> Products { get; }
    }
}
