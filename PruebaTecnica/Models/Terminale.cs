using System;
using System.Collections.Generic;

namespace PruebaTecnica.Models;

public partial class Terminal
{
    public int Codigo { get; set; }

    public string? Nombre { get; set; }

    public int? Estado { get; set; }
}
