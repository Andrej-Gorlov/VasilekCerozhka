namespace VasilekCerozhka.Helpers
{
    public class StaticDitels
    {
        public const string TokenCookie = "JWTToken";
        public static string? ProductApiBase { get; set; }
        public static string? CouponApiBase { get; set; }
        public static string? AuthApiBase { get; set; }
        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE,
            PATCH
        }

        public enum ContentType
        {
            Json,
            MultipartFormData,
        }
    }
}
