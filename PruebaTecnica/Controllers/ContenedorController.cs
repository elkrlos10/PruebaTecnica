using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Models;
using PruebaTecnica.Response;
using PruebaTecnica.ViewModel;

namespace PruebaTecnica.Controllers
{
    [Route("api/Contenedor")]
    [ApiController]
    public class ContenedorController : ControllerBase
    {
        private readonly PruebaTecnicaContext _context;

        public ContenedorController(PruebaTecnicaContext context)
        {
            _context = context;
        }

        [HttpGet()]
        [Route("GetContenedores")]
        public IActionResult GetContenedores()
        {
            var response = new ApiResponse();
            try
            {
                var contenedorViewModel = new ContenedorViewModel(_context);
                response.Datos = contenedorViewModel.GetContenedores();
                response.Success = true;
            }
            catch (Exception e)
            {
                response.Mensaje = e.Message;

            }

            return Ok(response);

        }

        [HttpGet()]
        [Route("GetContenedoresXNaviera")]
        public IActionResult GetContenedoresxNaviera(int idNaviera)
        {
            var response = new ApiResponse();
            try
            {
                var contenedorViewModel = new ContenedorViewModel(_context);
                response.Datos = contenedorViewModel.GetContenedoresxNaviera(idNaviera);
                response.Success = true;
            }
            catch (Exception e)
            {
                response.Mensaje = e.Message;

            }

            return Ok(response);

        }   
        
        [HttpGet()]
        [Route("GetTotalContenedoresXNaviera")]
        public IActionResult GetTotalContenedoresXNaviera()
        {
            var response = new ApiResponse();
            try
            {
                var contenedorViewModel = new ContenedorViewModel(_context);
                response.Datos = contenedorViewModel.GetTotalContenedoresXNaviera();
                response.Success = true;
            }
            catch (Exception e)
            {
                response.Mensaje = e.Message;

            }

            return Ok(response);

        }

        [HttpPost()]
        [Route("AddContenedor")]
        public IActionResult AddContenedor(ContenedorViewModel contenedorViewModel)
        {
            var response = new ApiResponse();
            try
            {
                contenedorViewModel._db = _context;
               var datos = contenedorViewModel.AddContenedor();
                if (datos != null) 
                {
                    response.Success = true;
                    response.Datos = datos;
                }
                else
                {
                    response.Mensaje = "No se adicionó el contenedor";
                }
                
            }
            catch (Exception e)
            {
                response.Mensaje = e.Message;

            }

            return Ok(response);

        }
    }
}
