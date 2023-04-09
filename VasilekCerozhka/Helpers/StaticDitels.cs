namespace VasilekCerozhka.Helpers
{
    public class StaticDitels
    {
        public static string? ProductApiBase { get; set; }
        public static string? CouponApiBase { get; set; }
        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE,
            PATCH
        }
    }
}
