using Datos.DataContext;
using GestionInventario.Models;
using GestionInventario.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Negocio.Service;
using System.Diagnostics;

namespace GestionInventario.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductoService _productoService;

        public HomeController(IProductoService productoServ)
        {
            _productoService = productoServ;
        }

        public async Task<IActionResult> Index()
        {
            var productos = await _productoService.ObtenerTodos();
            
            return View(productos);
        }

        [HttpPost]
        public async Task<JsonResult> ObtenerProducto() 
        {
            int NroPeticion = Convert.ToInt32(Request.Form["draw"].FirstOrDefault() ?? "0");
            int CantidadRegistros = Convert.ToInt32(Request.Form["length"].FirstOrDefault() ?? "0");
            int OmitirRegistros = Convert.ToInt32(Request.Form["start"].FirstOrDefault() ?? "0");
            string ValorBuscado = Request.Form["search[value]"].FirstOrDefault() ?? "";
            var consulta = await _productoService.LlenarTabla(OmitirRegistros, CantidadRegistros, ValorBuscado);
            var listaProductos = consulta.Productos;
            var Total = await _productoService.ObtenerTodos();
            var TotalRegistros =Total.Count();
            var TotalRegistrosFiltrados = consulta.TotalRegistrosFiltrados;

            return Json(new{draw = NroPeticion,recordsTotal = TotalRegistros,recordsFiltered = TotalRegistrosFiltrados,data = listaProductos,});
        }



        [HttpPost]
        public async Task<IActionResult> Insertar([Bind("IdProducto,Nombre,Proveedor,Cantidad,Precio,FechaV")]Producto producto)
        {
            if (ModelState.IsValid)
            {
                bool respuesta = await _productoService.Insertar(producto);           
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.ErrorMessage = "Hubo un error al insertar el producto en la base de datos";
                return View();
            }
        }

     

        [HttpPost]
        public async Task<IActionResult> Actualizar([Bind("IdProducto,Nombre,Proveedor,Cantidad,Precio,FechaV")]Producto producto)
        {


            if (ModelState.IsValid)
            {

                bool respuesta = await _productoService.Actualizar(producto);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.ErrorMessage = "Hubo un error al insertar el producto en la base de datos";
                return View();
            }


            
        }

        [HttpDelete]
        public async Task<IActionResult> Eliminar(int id)
        {
            bool respuesta = await _productoService.Eliminar(id);
            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });
        }

        [HttpPost]
        public async Task<IActionResult> Obtener(int id)
        {
            Producto respuesta = await _productoService.Obtener(id);
            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}