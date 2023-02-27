namespace VasilekCerozhka.Models.ProductAPI.Image
{
    public interface IImageBase
    {
        public int ProductId { get; set; }
        string ImageUrl { get; set; }
    }
}
