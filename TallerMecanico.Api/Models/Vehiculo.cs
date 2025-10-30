using System.ComponentModel.DataAnnotations;

namespace TallerMecanico.Api.Models
{
    public class Vehiculo
    {
        public int Id { get; set; } // Clave primaria
        public required string Patente { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Anio { get; set; }

        // Clave foránea (FK) para relacionarlo con Cliente
        public int ClienteId { get; set; }

        // Propiedad de navegación: Un vehículo pertenece a UN cliente
        public virtual Cliente Cliente { get; set; }
    }
}
