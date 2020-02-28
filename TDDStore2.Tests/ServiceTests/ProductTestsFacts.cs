using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Linq;
using System.Threading.Tasks;
using TDDStore2.DataAccess.Models;
using TDDStore2.DataAccess.Services;
using TDDStore2.DataAccess.VIewModels;
using Xunit;

namespace TDDStore2.Tests.ServiceTests
{
    public class ProductTestsFacts
    {
        private readonly ApplicationDbContext _context;
        public ProductTestsFacts()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;

            _context = new ApplicationDbContext(options);

            _context.Database.EnsureCreated();
        }

        [Fact]
        public void CreateProductSuccess()
        {
            //act
            // create genre
            var genre = new Genre { Name = "Weapon" };
            _context.Genres.Add(genre);
            _context.SaveChanges();

            //create product
            var product1 = new Product { Name = "AK-47", Price = 2000, Stock = 20, GenreID = genre.GenreID };
            var product2 = new Product { Name = "FN-FAL", Price = 2500, Stock = 15, GenreID = genre.GenreID };
            _context.Products.Add(product1);
            _context.Products.Add(product2);
            _context.SaveChanges();

            //arrange
            var list = _context.Products.ToList();

            //assert
            Assert.Equal(2, list.Count);
            Dispose();
            
        }

        private void Dispose()
        {
            _context.Database.EnsureDeleted();

            _context.Dispose();
        }
    }
}
