using Moq;
using System;
using System.Threading.Tasks;
using TDDStore2.DataAccess.Models;
using TDDStore2.DataAccess.Services;
using Xunit;

namespace TDDStore2.Tests
{
    public class ProductTestsFacts
    {
        [Fact]
        public void CreateProductSuccess()
        {
            var product = new Product { Name = "AK-47", Price = 2000, Stock = 20, GenreID = 1 };
            var mock = new Mock<IProductService>().Setup(x => x.CreateProduct(product)).Returns(Task.FromResult(product));
        }
    }
}
