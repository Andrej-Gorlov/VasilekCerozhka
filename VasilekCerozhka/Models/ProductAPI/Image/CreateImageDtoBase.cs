namespace VasilekCerozhka.Models.ProductAPI.Image
{
    public class CreateImageDtoBase
    {
        public int ProductId { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
    }
}
