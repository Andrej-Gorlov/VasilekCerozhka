namespace VasilekCerozhka.Models.ViewModels.Product
{
    public class ProductVM
    {
        public List<ProductDtoBase>? products { get; set; }
        public PagedList? Paging { get; set; }
    }
}
