namespace PruebaTecnica.Response
{
    public class ApiResponse
    {
        public bool Success { get; set; }
        public string Mensaje { get; set; }
        public object Datos { get; set; }

        public ApiResponse()
        {
            this.Success = false;
        }
    }
}
