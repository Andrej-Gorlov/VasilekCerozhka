namespace VasilekCerozhka.Models.ProductAPI.Image
{
    public class UpdateImageDtoBase : IImageBase
    {
        public int ProductId { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
    }
}
