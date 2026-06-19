namespace webAPI_membro.Models
{
    public class ServiceResponse<T>       //T e que recebe dados genericos
    {
        public T? Dados { get; set; }
        public string Mensagem { get; set; } = string.Empty;
        public bool Sucesso { get; set; } = true;
    }
}
