using Datos.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repositorio
{
    public class ProductoRepository : IGenericRepository<Producto>
    {
        private readonly InventarioDbContext _inventarioDbContext;

        public ProductoRepository(InventarioDbContext context)           
        {
            _inventarioDbContext = context;
        }

        public async Task<bool> Actualizar(Producto modelo)
        {
            _inventarioDbContext.Productos.Update(modelo);
            await _inventarioDbContext.SaveChangesAsync();
            return true;    
        }

        public async Task<bool> Eliminar(int id)
        {
            Producto modelo = _inventarioDbContext.Productos.First(c => c.IdProducto == id);
            _inventarioDbContext.Productos.Remove(modelo);
            await _inventarioDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Insertar(Producto modelo)
        {
            _inventarioDbContext.Productos.Add(modelo);
            await _inventarioDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<Producto> Obtener(int id)
        {
            return await _inventarioDbContext.Productos.FindAsync(id);
        }

        public async Task<IQueryable<Producto>> ObtenerTodos()
        {
            IQueryable<Producto> query = _inventarioDbContext.Productos;
            return query;
        }


 
    }
}
