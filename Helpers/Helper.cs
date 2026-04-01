namespace ABDM.Helpers
{
    public class Helper
    {

    }

    public class ApiResponse<T>
    {
        public bool Success {  get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public ApiResponse(bool success,int statusCode,string message,T data = default) 
        {
            this.Success = success;
            this.StatusCode = statusCode;
            this.Message = message;
            this.Data = data;
        }
    }


}
