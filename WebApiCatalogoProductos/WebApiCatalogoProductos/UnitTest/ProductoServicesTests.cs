using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using WebApiCatalogoProductos.Entities;
using WebApiCatalogoProductos.Interfaces;
using WebApiCatalogoProductos.Services;
using Xunit;

namespace WebApiCatalogoProductos.UnitTest.Services
{
    public class ProductoServicesTests
    {
        private readonly Mock<IProductoRepository> _productoRepositoryMock;
        private readonly ProductoServices _productoServices;

        public ProductoServicesTests()
        {
            _productoRepositoryMock = new Mock<IProductoRepository>();
            _productoServices = new ProductoServices(_productoRepositoryMock.Object);
        }

        [Fact]
        public async Task ObtenerListadoDeProductos_DeberiaRetornarListaDeProductos()
        {
            // Arrange
            var productosEsperados = new List<Producto>
            {
                new Producto { Id = 1, Nombre = "Producto 1" },
                new Producto { Id = 2, Nombre = "Producto 2" }
            };

            _productoRepositoryMock
                .Setup(repo => repo.ObtenerListadoDeProductos())
                .ReturnsAsync(productosEsperados);

            // Act
            var resultado = await _productoServices.ObtenerListadoDeProductos();

            // Assert
            Assert.Equal(productosEsperados, resultado);
            _productoRepositoryMock.Verify(repo => repo.ObtenerListadoDeProductos(), Times.Once);
        }

        [Fact]
        public async Task ObtenerProductoPorId_DeberiaRetornarProducto()
        {
            // Arrange
            var producto = new Producto { Id = 1, Nombre = "Producto 1" };

            _productoRepositoryMock
                .Setup(repo => repo.ObtenerProductoPorId(1))
                .ReturnsAsync(producto);

            // Act
            var resultado = await _productoServices.ObtenerProductoPorId(1);

            // Assert
            Assert.Equal(producto, resultado);
            _productoRepositoryMock.Verify(repo => repo.ObtenerProductoPorId(1), Times.Once);
        }

        [Fact]
        public async Task AgregarProducto_DeberiaLlamarAlRepositorio()
        {
            // Arrange
            var producto = new Producto { Id = 1, Nombre = "Nuevo Producto" };

            _productoRepositoryMock
                .Setup(repo => repo.AgregarProducto(producto))
                .Returns(Task.CompletedTask);

            // Act
            await _productoServices.AgregarProducto(producto);

            // Assert
            _productoRepositoryMock.Verify(repo => repo.AgregarProducto(producto), Times.Once);
        }

        [Fact]
        public async Task ActualizarProducto_DeberiaLlamarAlRepositorio()
        {
            // Arrange
            var producto = new Producto { Id = 1, Nombre = "Producto Actualizado" };

            _productoRepositoryMock
                .Setup(repo => repo.ActualizarProducto(producto))
                .Returns(Task.CompletedTask);

            // Act
            await _productoServices.ActualizarProducto(producto);

            // Assert
            _productoRepositoryMock.Verify(repo => repo.ActualizarProducto(producto), Times.Once);
        }

        [Fact]
        public async Task EliminarProducto_DeberiaLlamarAlRepositorio()
        {
            // Arrange
            var id = 1;

            _productoRepositoryMock
                .Setup(repo => repo.EliminarProducto(id))
                .Returns(Task.CompletedTask);

            // Act
            await _productoServices.EliminarProducto(id);

            // Assert
            _productoRepositoryMock.Verify(repo => repo.EliminarProducto(id), Times.Once);
        }
    }
}
