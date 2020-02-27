using Moq;
using System;
using System.Threading.Tasks;
using TDDStore2.DataAccess.Models;
using TDDStore2.DataAccess.Services;
using TDDStore2.DataAccess.VIewModels;
using Xunit;

namespace TDDStore2.Tests
{
    public class ProductTestsFacts
    {
        [Fact]
        public void CreateProductSuccess()
        {
            var model = new ProductViewModel { Name = "AK-47", Price = 2000, Stock = 20, GenreID = 1 };
            var product = new Product { Name = model.Name, Price = model.Price, Stock = model.Stock, GenreID = model.GenreID };
            var mock = new Mock<IProductService>().Setup(x => x.CreateProduct(model)).Returns(Task.FromResult(product));
        }
    }
}
