namespace GestionInventario.Models.ViewModels
{
    public class VMProducto
    {
        public int IdProducto { get; set; }

        public string Nombre { get; set; } = null!;

        public string Proveedor { get; set; } = null!;

        public int Cantidad { get; set; }

        public decimal Precio { get; set; }

        public DateTime FechaV { get; set; }
    }
}
