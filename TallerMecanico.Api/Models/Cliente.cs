namespace TallerMecanico.Api.Models
{
    public class Cliente
    {
        public int Id { get; set; } // Clave primaria
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }

        // Propiedad de navegación: Un cliente puede tener MUCHOS vehículos
        public virtual ICollection<Vehiculo> Vehiculos { get; set; } = new List<Vehiculo>();
    }
}
