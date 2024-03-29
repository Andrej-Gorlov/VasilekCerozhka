﻿namespace VasilekCerozhka.Models.ProductAPI.Image
{
    public class ImageDtoBase : IImageBase
    {
        public int ImageId { get; set; }
        public int ProductId { get; set; }
        [Display(Name = "Url Изображения")]
        public string ImageUrl { get; set; } = string.Empty;
    }
}
