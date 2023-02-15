using System;
using System.Collections.Generic;

namespace PruebaTecnica.Models;

public partial class Naviera
{
    public int Codigo { get; set; }

    public string? Nombre { get; set; }

    public string? Telefono { get; set; }

    public int? Estado { get; set; }
}
