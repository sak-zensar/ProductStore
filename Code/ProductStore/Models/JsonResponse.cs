namespace Models
{
    public class JsonResponse
    {
        public bool IsValid { get; set; }
        public dynamic ResultData { get; set; }
        public string ErrorMessage { get; set; }
        public int StatusCode { get; set; }
    }
}
