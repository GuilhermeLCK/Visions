namespace Visions.Domain.Models
{
    public class GerericResponse
    {
        public bool Success { get; set; }
        public List<string> Messages { get; set; }

        public GerericResponse(bool success, List<string>? message = null)
        {
            Success = success;
            Messages = message ?? new List<string>();
        }
    }
    public class GerericResponse<T> : GerericResponse
    {
        public T Data { get; set; }

        public GerericResponse(T data, bool successs = true, List<string>? message = null)
            : base(successs, message)
        {
            Data = data;
        }
    }
}
