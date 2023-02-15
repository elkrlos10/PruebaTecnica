using Microsoft.Identity.Client;
using PruebaTecnica.AutoMaper;
using PruebaTecnica.Models;

namespace PruebaTecnica.ViewModel
{
    public class TerminalViewModel : Mapeador
    {
        public PruebaTecnicaContext _db;

        public int Codigo { get; set; }

        public string? Nombre { get; set; }

        public int? Estado { get; set; }

        public TerminalViewModel()
        {
        }
        public TerminalViewModel(PruebaTecnicaContext db)
        {
            _db = db; 
        }

        public List<Terminal> GetTerminales()
        {
            return _db.Terminales.Where(x => x.Estado == 1).ToList();
        }

        public Terminal AddTerminal() 
        {
            var terminal = Mapear<Terminal>();
            terminal.Codigo = 0;
            _db.Terminales.Add(terminal);
            _db.SaveChanges();
            return terminal;
        }

    }
}
