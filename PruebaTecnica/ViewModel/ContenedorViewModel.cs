using PruebaTecnica.AutoMaper;
using PruebaTecnica.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaTecnica.ViewModel
{
    public class ContenedorViewModel : Mapeador
    {
        public PruebaTecnicaContext _db;
        public int Id { get; set; }

        public string? Prefijo { get; set; }

        public string? Numero { get; set; }

        public string? DigitoControl { get; set; }

        public int? Idnaviera { get; set; }

        [Column(TypeName = "date")]
        public DateTime Fechafabricacion { get; set; }

        public decimal? Tara { get; set; }

        public ContenedorViewModel()
        {
        }
        public ContenedorViewModel(PruebaTecnicaContext db)
        {
            _db = db;
        }

        public List<Contenedor> GetContenedores()
        {
            return _db.Contenedores.ToList();
        }

        public dynamic GetContenedoresxNaviera(int idNaviera)
        {
            return (from c in _db.Contenedores
                    join n in _db.Navieras on c.Idnaviera equals n.Codigo
                    where c.Idnaviera == idNaviera
                    select new
                    {
                        c.Id,
                        c.Prefijo,
                        c.Numero,
                        c.DigitoControl,
                        c.Idnaviera,
                        Naviera = n.Nombre,
                        c.Tara
                    });
        }

        public dynamic GetTotalContenedoresXNaviera()
        {
            return (from n in _db.Navieras
                    select new
                    {
                        n.Codigo,
                        Naviera = n.Nombre,
                        n.Telefono,
                        n.Estado,
                        totalContenedores = _db.Contenedores.Where(x => x.Idnaviera == n.Codigo).Count(),
                    });

        }

        public Contenedor AddContenedor()
        {
            var contenedor = Mapear<Contenedor>();
            var naviera = _db.Navieras.FirstOrDefault(x => x.Codigo == Idnaviera);
            if (naviera == null) return default;
            _db.Contenedores.Add(contenedor);
            _db.SaveChanges();
            return contenedor;
        }
    }
}
