﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[AllowAnonymous]
	[Route("Admin/Product")]
	public class ProductController : Controller
	{
		

		private readonly IHttpClientFactory _httpClientFactory;
		private readonly ILogger<ProductController> _logger;

		public ProductController(IHttpClientFactory httpClientFactory, ILogger<ProductController> logger)
		{
			_httpClientFactory = httpClientFactory;
			_logger = logger;
		}

		[Route("Index")]
		public async Task<IActionResult> Index()
		{
			ViewBag.v1 = "Ana Sayfa";
			ViewBag.v2 = "Ürünler";
			ViewBag.v3 = "Ürün Listesi";
			ViewBag.headTitle = "Ürün İşlemleri";

			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7070/api/Products/ProductListWithCategory");

			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
				return View(values);
			}
			return View();
		}


		[HttpGet]
		[Route("CreateProduct")]
		public async Task<IActionResult> CreateProduct()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7070/api/Categories");
			var jsonData = await responseMessage.Content.ReadAsStringAsync();
			var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);

			List<SelectListItem> categoryValues = (from x in values
												   select new SelectListItem
												   {
													   Text = x.CategoryName,
													   Value = x.CategoryID
												   }).ToList();

			ViewBag.CategoryValues = categoryValues;	
			return View();
		}

		[HttpPost]
		[Route("CreateProduct")]
		public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
		{

			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createProductDto);

			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

			var responseMessage = await client.PostAsync("https://localhost:7070/api/Products", stringContent);

			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "Product", new { area = "Admin" });
			}

			return View();
		}

		[HttpGet]
		[Route("DeleteProduct/{id}")]
		public async Task<IActionResult> DeleteProduct(string id)
		{

			var client = _httpClientFactory.CreateClient();

			var responseMessage = await client.DeleteAsync("https://localhost:7070/api/Products?id="+id);

			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "Product", new { area = "Admin" });
			}

			return View();
		}

		[Route("UpdateProduct/{id}")]
		[HttpGet]
		public async Task<IActionResult> UpdateProduct(string id)
		{


			ViewBag.v1 = "Ana Sayfa";
			ViewBag.v2 = "Ürünler";
			ViewBag.v3 = "ürün güncelleme";
			ViewBag.headTitle = "ürün İşlemleri";

			var client1 = _httpClientFactory.CreateClient();
			var responseMessage1 = await client1.GetAsync("https://localhost:7070/api/Categories");
			var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
			var values1 = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData1);

			List<SelectListItem> categoryValues = (from x in values1
												   select new SelectListItem
												   {
													   Text = x.CategoryName,
													   Value = x.CategoryID
												   }).ToList();

			ViewBag.CategoryValues = categoryValues;



			var client = _httpClientFactory.CreateClient();


			var responseMessage = await client.GetAsync("https://localhost:7070/api/Products/" + id);

			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateProductDto>(jsonData);
				return View(values);
			}



			return View();
		}

		[Route("UpdateProduct/{id}")]
		[HttpPost]
		public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
		{

			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updateProductDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");


			

			var responseMessage = await client.PutAsync("https://localhost:7070/api/Products/", stringContent);
			var responseContent = await responseMessage.Content.ReadAsStringAsync();

			_logger.LogInformation(responseContent);


			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "Product", new { area = "Admin" });
			}

			return View();
		}
	}
}