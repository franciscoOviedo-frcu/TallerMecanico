namespace TallerMecanico.Api.Models
{
    using System.Text.Json.Serialization;
    public class Trabajo
    {
        public int id { get; set; }
        public DateTime fechaAsignacion { get; set; }
        public DateTime? fechaFinalizacion { get; set; }

        public DateTime? fechaPago { get; set; }
        public float monto { get; set; }
        public string descripcionArreglo { get; set; }
        public EstadoTrabajo estado { get; set; } = new EstadoTrabajo();

        //[Required]
        [JsonIgnore]
        public Vehiculo? vehiculo { get; set; }
    }


    public enum EstadoTrabajo
    {
        Pendiente,
        EnCurso,
        FinalizadoConPagoPendiente,
        FinalizadoPagado,
        Cancelado

    }
}
