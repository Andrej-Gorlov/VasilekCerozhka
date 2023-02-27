using VasilekCerozhka.Models.ProductAPI.Image;

namespace VasilekCerozhka.Services.Helpers
{
    public class SetParams
    {
        public int IdParams(string idParams)
        {
            int id;
            if (idParams != null)
            {
                if (int.TryParse(idParams, out id))
                    return id;
            }
            return -1;
        }
        public List<T>? Images<T>(List<string> images) where T : IImageBase, new() =>
        
             images.Select(x => new T { ImageUrl = x }).ToList() ?? null;
    }
}
