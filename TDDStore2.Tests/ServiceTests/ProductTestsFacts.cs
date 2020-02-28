using Moq;
using System;
using System.Threading.Tasks;
using TDDStore2.DataAccess.Models;
using TDDStore2.DataAccess.Services;
using TDDStore2.DataAccess.VIewModels;
using Xunit;

namespace TDDStore2.Tests.ServiceTests
{
    public class ProductTestsFacts
    {
        // Create tests
        [Fact]
        public void CreateProductSuccess()
        {
            var model = new ProductViewModel { Name = "AK-47", Price = 2000, Stock = 20, GenreID = 1 };
            var product = new Product { Name = model.Name, Price = model.Price, Stock = model.Stock, GenreID = model.GenreID };
            var mock = new Mock<IProductService>().Setup(x => x.CreateProduct(model)).Returns(Task.FromResult(product));
        }
        [Fact]
        public void CreateEmptyProductFail()
        {
            var model = new ProductViewModel();
            var mock = new Mock<IProductService>().Setup(x => x.CreateProduct(model)).Throws(new Exception());
        }
        [Fact]
        public void CreateProductWithoutGenreFails()
        {
            var model = new ProductViewModel { Name = "AK-47", Price = 2000, Stock = 20 };
            var mock = new Mock<IProductService>().Setup(x => x.CreateProduct(model)).Throws(new Exception());
        }
        [Fact]
        public void CreateProductWithNegativePriceFails()
        {
            var model = new ProductViewModel { Name = "AK-47", Price = -1, Stock = 20 };
            var mock = new Mock<IProductService>().Setup(x => x.CreateProduct(model)).Throws(new Exception());
        }
    }
}
