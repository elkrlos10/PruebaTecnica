using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Models;
using PruebaTecnica.Response;
using PruebaTecnica.ViewModel;
using System.Security.Claims;

namespace PruebaTecnica.Controllers
{
    [Route("api/terminal")]
    [ApiController]
    public class TerminalController : ControllerBase
    {

        private readonly PruebaTecnicaContext _context;

        public TerminalController(PruebaTecnicaContext context)
        {
            _context = context;
        } 

        [HttpGet()]
        [Route("GetTerminales")]
        public IActionResult GetTerminales()
        {
            var response = new ApiResponse();
            try
            {
                var terminalViewModel = new TerminalViewModel(_context);
                response.Datos = terminalViewModel.GetTerminales();
                response.Success = true;
            }
            catch (Exception e)
            {
                response.Mensaje = e.Message;

            }

            return Ok(response);
        
        }

        [HttpPost()]
        [Route("AddTerminal")]
        public IActionResult AddTerminal(TerminalViewModel terminalViewModel)
        {
            var response = new ApiResponse();
            try
            {
                terminalViewModel._db = _context;
                response.Datos = terminalViewModel.AddTerminal();
                response.Success = true;
            }
            catch (Exception e)
            {
                response.Mensaje = e.Message;

            }

            return Ok(response);

        }
    }
}
