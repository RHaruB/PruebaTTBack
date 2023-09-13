namespace PruebaTTBack.ViewModels
{
    public class ResponseVM
    {
        public string? Codigo_Error { set; get; }
        public string? Mensaje { get; set; }
        public bool? Ejecutado { get; set; }
        public object? Data { get; set; }
    }
}