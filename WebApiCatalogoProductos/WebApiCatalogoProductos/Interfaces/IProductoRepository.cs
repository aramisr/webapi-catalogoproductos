using WebApiCatalogoProductos.Entities;

namespace WebApiCatalogoProductos.Interfaces
{
    public interface IProductoRepository
    {
        Task<IEnumerable<Producto>> ObtenerListadoDeProductos();
        Task<Producto> ObtenerProductoPorId(int id);
        Task AgregarProducto(Producto producto);
        Task ActualizarProducto(Producto producto);
        Task EliminarProducto(int id);
    }
}
