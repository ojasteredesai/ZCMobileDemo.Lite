namespace ZCMobileDemo.Lite.Model
{
    public class LogErrorRequest 
    {
        //public object UIException { get; set; }
        public string ErrorMessage { get; set; }
        public string Title { get; set; }        
    }

    public class LogErrorResponse
    {
        public bool ResultSuccess { get; set; }
    }
}
