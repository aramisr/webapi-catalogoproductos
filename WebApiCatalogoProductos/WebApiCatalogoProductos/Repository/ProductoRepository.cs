using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using WebApiCatalogoProductos.Entities;
using WebApiCatalogoProductos.Interfaces;

namespace WebApiCatalogoProductos.Repository
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly string _connectionString;

        public ProductoRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<Producto>> ObtenerListadoDeProductos()
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryAsync<Producto>("sp_ObtenerProductos", commandType: CommandType.StoredProcedure);
        }

        public async Task<Producto> ObtenerProductoPorId(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryFirstOrDefaultAsync<Producto>("sp_ObtenerProductoPorId", new { Id = id }, commandType: CommandType.StoredProcedure);
        }

        public async Task AgregarProducto(Producto producto)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.ExecuteAsync("sp_AgregarProducto", new
            {
                producto.Nombre,
                producto.Descripcion,
                producto.Imagen,
                producto.PrecioBase,
                producto.PrecioConDescuento
            }, commandType: CommandType.StoredProcedure);
        }

        public async Task ActualizarProducto(Producto producto)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.ExecuteAsync("sp_ActualizarProducto", new
            {
                producto.Id,
                producto.Nombre,
                producto.Descripcion,
                producto.Imagen,
                producto.PrecioBase,
                producto.PrecioConDescuento
            }, commandType: CommandType.StoredProcedure);
        }

        public async Task EliminarProducto(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.ExecuteAsync("sp_EliminarProducto", new { Id = id }, commandType: CommandType.StoredProcedure);
        }
    }
}
