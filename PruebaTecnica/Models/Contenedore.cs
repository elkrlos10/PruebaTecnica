using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaTecnica.Models;

public partial class Contenedor
{
    public int Id { get; set; }

    public string? Prefijo { get; set; }

    public string? Numero { get; set; }

    public string? DigitoControl { get; set; }

    public int? Idnaviera { get; set; }

    [Column(TypeName = "date")]
    public DateTime Fechafabricacion { get; set; }

    public decimal? Tara { get; set; }

    //public virtual Naviera Naviera { get; set; }

}
