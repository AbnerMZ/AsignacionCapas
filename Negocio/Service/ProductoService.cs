using Datos.DataContext;
using Datos.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Service
{
    public class ProductoService : IProductoService
    {
        private readonly IGenericRepository<Producto> _productRepo;
        public ProductoService(IGenericRepository<Producto> productRepo)
        {
            _productRepo=productRepo;
        }
        public async Task<bool> Actualizar(Producto modelo)
        {
            return await _productRepo.Actualizar(modelo);
        }

        public async Task<bool> Eliminar(int id)
        {
            return await _productRepo.Eliminar(id);
        }

        public async Task<bool> Insertar(Producto modelo)
        {
            return await _productRepo.Insertar(modelo);
        }

        public async Task<Producto> Obtener(int id)
        {
            return await _productRepo.Obtener(id);
        }

        public async Task<IQueryable<Producto>> ObtenerTodos()
        {
            return await _productRepo.ObtenerTodos();
        }
    }
}
