namespace VasilekCerozhka.Models.ProductAPI.Image
{
    public class UpdateImageDtoBase
    {
        public int ImageId { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
    }
}
