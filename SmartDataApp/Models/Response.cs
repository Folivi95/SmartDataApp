namespace SmartDataApp.Models
{
    public class BaseResponse
    {
        public bool success { get; set; }
        public string message { get; set; }
    }
    public static class Response<T>
    {
        public static BaseResponse InternalError(string exceptionMessage)
        {
            return new BaseResponse
            {
                success = false,
                message = exceptionMessage
            };
        }
    }

    public class PagedResponse<T>
    {
        public bool success { get; set; }
        public string message { get; set; }
        public T data { get; set; }
        public Meta meta { get; set; }
    }

    public class Meta
    {
        public Pagination pagination { get; set; }
    }

    public class Pagination
    {
        public string currentPage { get; set; }
        public string nextPage { get; set; }
        public string previousPage { get; set; }
        public int totalPages { get; set; }
        public int perPage { get; set; }
        public int totalEntries { get; set; }
    }
}