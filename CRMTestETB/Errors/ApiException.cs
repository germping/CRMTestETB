namespace API.Errors
{
    public class ApiException: ApiErrorResponse
    {
        public ApiException(int statusCode, string messageError=null, string detail = null ):base(statusCode, messageError)
        {
            Detail = detail;
        }

        public String Detail { get; set; }
    }
}
