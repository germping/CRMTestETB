namespace API.Errors
{
    public class ApiErrorResponse
    {
        public ApiErrorResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetMessageStatusCode(statusCode);
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }

        private string GetMessageStatusCode(int statusCode) 
        {
            return statusCode switch
            {
                400 => "Se ha realizado una solicitud no valida",
                401 => "No esta autorizado",
                404 => "Recurso no dispnible",
                500 => "Error interno",
                _ => null
            };
        }
    }
}
