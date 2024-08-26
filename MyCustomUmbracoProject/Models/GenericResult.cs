namespace MyCustomUmbracoProject.Models
{
    public class GenericResult<T>
    {
        public T Data { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; } = null;
        public string Error { get; set; } = null;
        public IEnumerable<string> ErrorMessages { get; set; } = Enumerable.Empty<string>();
    }
}