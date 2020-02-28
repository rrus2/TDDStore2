using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Moq;
using TDDStore2.DataAccess.Models;
using TDDStore2.DataAccess.Services;
using TDDStore2.DataAccess.VIewModels;
using Xunit;

namespace TDDStore2.Tests.ServiceTests
{
    public class ProductTestsTheories
    {
        private readonly ApplicationDbContext _context;
        public ProductTestsTheories()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            _context = new ApplicationDbContext(options);
            _context.Database.EnsureCreated();
        }

        [Theory]
        [InlineData("AK-47", 2000, 20)]
        [InlineData("FN-FAL", 2500, 25)]
        public void GetProductsSuccess(string name, decimal price, int stock)
        {
            //arrange
            var product1 = new Product { Name = name, Price = price, Stock = stock };
            var product2 = new Product { Name = "TEST", Price = 0, Stock = int.MinValue };
            _context.Products.Add(product1);
            _context.Products.Add(product2);
            _context.SaveChanges();

            //act
            var list = _context.Products.ToList();

            //assert
            Assert.NotNull(list);
            Assert.Contains(product1, list);
            Assert.Equal(2, list.Count);
            Dispose();
        }

        [Theory]
        [InlineData("AK-47", 2000, 20)]
        [InlineData("FN-FAL", 2500, 25)]
        [InlineData("AK", 2000, int.MaxValue)]
        public void CreateProductSuccess(string name, decimal price, int stock)
        {
            //arrange
            var product = new Product { Name = name, Price = price, Stock = stock };
            _context.Products.Add(product);
            _context.SaveChanges();

            //act
            var list = _context.Products.ToList();

            //assert
            Assert.NotNull(list);
            Dispose();
        }

        [Theory]
        [InlineData("AK-47", 2000, 20)]
        [InlineData("FN-FAL", 2500, 25)]
        public void UpdateProductSuccess(string name, decimal price, int stock)
        {
            //arrange
            var model = new Product { Name = name, Price = price, Stock = stock };
            _context.Products.Add(model);
            _context.SaveChanges();

            //act
            var product = _context.Products.FirstOrDefault(x => x.ProductID == model.ProductID);
            product.Name = "TEST";
            product.Price = 1;
            product.Stock = int.MaxValue;
            _context.SaveChanges();

            //assert
            Assert.NotNull(product);
            Assert.Equal("TEST", product.Name);
            Assert.Equal(1, product.Price);
            Assert.Equal(int.MaxValue, product.Stock);
            Dispose();
        }

        private void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }
    }
}
