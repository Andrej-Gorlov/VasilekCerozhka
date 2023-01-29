﻿using Microsoft.AspNetCore.Mvc.Rendering;
using VasilekCerozhka.Models.Paging;
using VasilekCerozhka.Models.ProductAPI.Product;

namespace VasilekCerozhka.Models.ViewModels.Product
{
    public class ProductVM
    {
        public List<ProductDtoBase>? products { get; set; }
        public PagedList? Paging { get; set; }
        public IEnumerable<SelectListItem> Categorys { get; set; }
    }
}
