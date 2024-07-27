namespace MultiShop.Catalog.Dtos.ProductDtos
{
	public class ResultProductsWithCategoryDto
	{
		public string ProductID { get; set; }
		public string ProductName { get; set; }
		public decimal Price { get; set; }
		public string ProductImageUrl { get; set; }
		public string ProductDescription { get; set; }
		public string CategoryId { get; set; }

		public string CategoryName { get; set; }
	}
}
