using System.Text.Json.Serialization;

namespace TallerMecanico.Web.Models
{
    // CLASE 1: Para las MARCAS (El código viene como STRING "59")
    public class FipeItem
    {
        [JsonPropertyName("nome")]
        public string Nombre { get; set; }

        [JsonPropertyName("codigo")]
        public string Codigo { get; set; }
    }

    // CLASE 2: Para los MODELOS (El código viene como NÚMERO 5585)
    public class FipeModelo
    {
        [JsonPropertyName("nome")]
        public string Nombre { get; set; }

        [JsonPropertyName("codigo")]
        public long Codigo { get; set; } // Usamos 'long' o 'int' porque es un número
    }

    // CLASE 3: La respuesta de la API que trae la lista de modelos
    public class FipeModeloResponse
    {
        [JsonPropertyName("modelos")]
        public List<FipeModelo> Modelos { get; set; } // Ahora usa la clase nueva

        [JsonPropertyName("anos")]
        public List<FipeItem> Anios { get; set; }
    }
}