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
        [InlineData("AK", 2000, int.MaxValue)]
        public void CreateProductSuccess(string name, decimal price, int stock)
        {
            //act
            var product = new Product { Name = name, Price = price, Stock = stock };
            _context.Products.Add(product);
            _context.SaveChanges();

            //arrange
            var list = _context.Products.ToList();

            //assert
            Assert.NotNull(list);
        }


        private void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }
    }
}
