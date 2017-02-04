namespace BleutradeOperator.Response
{
    public abstract class BaseResponse<T> where T : class
    {
        public bool success { get; set; }
        public string message { get; set; }
    }
}