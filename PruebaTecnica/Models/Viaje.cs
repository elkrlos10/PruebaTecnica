using System;
using System.Collections.Generic;

namespace PruebaTecnica.Models;

public partial class Viaje
{
    public int ViajesId { get; set; }

    public string? Contenedor { get; set; }

    public string? Pais { get; set; }

    public DateTime? FechaViaje { get; set; }

    public int? Idnaviera { get; set; }
}
