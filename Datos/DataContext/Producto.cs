using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Datos.DataContext;

public partial class Producto
{
    [Key]
    public int IdProducto { get; set; }

    public string Nombre { get; set; } = null!;

    public string Proveedor { get; set; } = null!;

    public int Cantidad { get; set; }

    public decimal Precio { get; set; }

    [Display(Name = "Fecha De Vencimiento")]
    public DateTime FechaV { get; set; }
}
