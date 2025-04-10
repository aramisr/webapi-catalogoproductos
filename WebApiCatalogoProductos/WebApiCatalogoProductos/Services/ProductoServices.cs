using WebApiCatalogoProductos.Entities;
using WebApiCatalogoProductos.Interfaces;

namespace WebApiCatalogoProductos.Services
{
    public class ProductoServices : IProductoServices
    {
        private readonly IProductoRepository _productoRepository;

        public ProductoServices(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public Task<IEnumerable<Producto>> ObtenerListadoDeProductos()
        {
            return _productoRepository.ObtenerListadoDeProductos();
        }
        public Task<Producto> ObtenerProductoPorId(int id)
        {
            return _productoRepository.ObtenerProductoPorId(id);
        }
        public Task AgregarProducto(Producto producto)
        {
            return _productoRepository.AgregarProducto(producto);
        }
        public Task ActualizarProducto(Producto producto)
        {
            return _productoRepository.ActualizarProducto(producto);
        }
        public Task EliminarProducto(int id)
        {
            return _productoRepository.EliminarProducto(id);
        }
    }
}
