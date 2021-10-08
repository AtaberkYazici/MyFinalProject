﻿using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory {
    public class InMemoryProductDal : IProductDal {

        List<Product> _products;
        public InMemoryProductDal() {
            _products = new List<Product> {
                new Product{ProductId=1,CategoryId=1,ProductName="Bardak",UnitPrice=15,UnitsInStock=15},
                new Product{ProductId=1,CategoryId=1,ProductName="Kamera",UnitPrice=500,UnitsInStock=3},
                new Product{ProductId=1,CategoryId=1,ProductName="Telefon",UnitPrice=1500,UnitsInStock=2},
                new Product{ProductId=1,CategoryId=1,ProductName="Klavye",UnitPrice=150,UnitsInStock=65},
                new Product{ProductId=1,CategoryId=1,ProductName="Fare",UnitPrice=85,UnitsInStock=1},
            };
        }

        public void Add(Product product) {
            _products.Add(product);
        }

        public void Delete(Product product) {

            Product productToDelete = _products.SingleOrDefault(p=>p.ProductId==product.ProductId);

            _products.Remove(productToDelete);
        }

        public List<Product> GetAll() {
            return _products;
        }

        public List<Product> GetAllByCategory(int categoryId) {
               return _products.Where(p=> p.CategoryId == categoryId).ToList();
        }

        public void Update(Product product) {
            Product productToUpDate = _products.SingleOrDefault(p=>p.ProductId==product.ProductId);
            productToUpDate.ProductName = product.ProductName;
            productToUpDate.CategoryId=product.CategoryId;
            productToUpDate.UnitPrice=product.UnitPrice;
            productToUpDate.UnitsInStock=product.UnitsInStock;

        }
    }
}
