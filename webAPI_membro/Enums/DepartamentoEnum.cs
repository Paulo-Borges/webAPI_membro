using System.Text.Json.Serialization;

namespace webAPI_membro.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum DepartamentoEnum
    {
        Pastor,
        Lider,
        Presbitero,
        Diacono,
        Diaconisa,
        Tesoureiro,
        Secretario
    }
}
