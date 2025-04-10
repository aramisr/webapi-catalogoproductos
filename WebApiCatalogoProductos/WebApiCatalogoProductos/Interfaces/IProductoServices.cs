using WebApiCatalogoProductos.Entities;

namespace WebApiCatalogoProductos.Interfaces
{
    public interface IProductoServices
    {
        Task<IEnumerable<Producto>> ObtenerListadoDeProductos();
        Task<Producto> ObtenerProductoPorId(int id);
        Task AgregarProducto(Producto producto);
        Task ActualizarProducto(Producto producto);
        Task EliminarProducto(int id);
    }
}
