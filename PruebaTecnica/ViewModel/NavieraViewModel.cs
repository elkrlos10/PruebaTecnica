using PruebaTecnica.AutoMaper;
using PruebaTecnica.Models;

namespace PruebaTecnica.ViewModel
{
    public class NavieraViewModel: Mapeador
    {
        public PruebaTecnicaContext _db;

        public int Codigo { get; set; }

        public string? Nombre { get; set; }

        public string? Telefono { get; set; }

        public int? Estado { get; set; }
        public NavieraViewModel() { }

        public NavieraViewModel(PruebaTecnicaContext db)
        {
            _db= db;
        }

        public List<Naviera> GetNavieras() 
        { 
            return _db.Navieras.Where(x=>x.Estado==1).ToList();
        }

        public Naviera AddNaviera() 
        {
            var naviera = Mapear<Naviera>();
            naviera.Codigo = 0;
            _db.Navieras.Add(naviera);
            _db.SaveChanges();
            return naviera;
        }
    }
}
