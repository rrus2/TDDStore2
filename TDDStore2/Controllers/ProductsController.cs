using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TDDStore2.DataAccess.Services;
using TDDStore2.DataAccess.VIewModels;

namespace TDDStore2.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly IGenreService _genreService;
        public ProductsController(IProductService productService, IGenreService genreService)
        {
            _productService = productService;
            _genreService = genreService;
        }
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetProducts();
            return View(products);
        }
        public async Task<IActionResult> Create()
        {
            await LoadGenres();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductViewModel model)
        {
            await _productService.CreateProduct(model);
            return View("ThankYouProductCreate");
        }
        public async Task<IActionResult> Details(int id)
        {
            var product = await _productService.GetProduct(id);
            return View(product);
        }
        public IActionResult ThankYouProductCreate()
        {
            return View();
        }
        private async Task LoadGenres()
        {
            var genres = await _genreService.GetGenres();
            var list = new SelectList(genres, "GenreID", "Name");
            ViewBag.Genres = list;
        }
    }
}