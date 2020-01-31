namespace EncryptionUtility.API.Models
{
    public class ApiOutput<T> where T : class
    {

        public int StatusCode { get; set; }
        public string Error { get; set; }

        public T Result { get; set; }
    }
}