using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Models;
using PruebaTecnica.Response;
using PruebaTecnica.ViewModel;

namespace PruebaTecnica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NavieraController : ControllerBase
    {
        private readonly PruebaTecnicaContext _context;

        public NavieraController(PruebaTecnicaContext context)
        {
            _context = context;
        }

        [HttpGet()]
        [Route("GetNavieras")]
        public IActionResult GetNavieras()
        {
            var response = new ApiResponse();
            try
            {
                var navieraViewModel = new NavieraViewModel(_context);
                response.Datos = navieraViewModel.GetNavieras();
                response.Success = true;
            }
            catch (Exception e)
            {
                response.Mensaje = e.Message;

            }

            return Ok(response);

        }

        [HttpPost()]
        [Route("AddNaviera")]
        public IActionResult AddNaviera(NavieraViewModel navieraViewModel)
        {
            var response = new ApiResponse();
            try
            {
                navieraViewModel._db = _context;
                response.Datos = navieraViewModel.AddNaviera();
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
