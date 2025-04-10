using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApiCatalogoProductos.DTOs;
using WebApiCatalogoProductos.Services;
using WebApiCatalogoProductos.Interfaces;
using WebApiCatalogoProductos.Entities;

namespace WebApiCatalogoProductos.Controllers
{
    [Route("api/catalogoproductos")]
    [ApiController]
    public class GestionarProductosController : ControllerBase
    {
        private readonly ILogger<GestionarProductosController> logger;
        private readonly IProductoServices _productoServices;
        private readonly IMapper mapper;

        
        public GestionarProductosController(ILogger<GestionarProductosController> logger, IProductoServices productoServices, IMapper mapper)
        {
            this.logger = logger;
            this._productoServices = productoServices;
            this.mapper = mapper;
        }

        [HttpGet("ObtenerListadoDeProductos")]
        public async Task<ActionResult<List<ProductoDTO>>> ObtenerListadoDeProductos()
        {
            var productos = await _productoServices.ObtenerListadoDeProductos();
            return mapper.Map<List<ProductoDTO>>(productos);
        }

        [HttpGet("ObtenerProductoPorId/{Id:int}")]
        public async Task<ActionResult<ProductoDTO>> ObtenerProductoPorId(int Id)
        {
            var producto = await _productoServices.ObtenerProductoPorId(Id);

            if (producto == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<ProductoDTO>(producto));
        }

        [HttpPost("AgregarProducto")]
        public async Task<ActionResult> Post([FromBody] ProductoDTO productoDTO)
        {
            var producto = mapper.Map<Producto>(productoDTO);
            await _productoServices.AgregarProducto(producto);
            return Ok(new { message = "Producto agregado correctamente" });
        }

        [HttpPut("ActualizarProducto")]
        public async Task<ActionResult> ActualizarProducto(int Id, [FromBody] ProductoDTO productoDTO)
        {
            var producto = mapper.Map<Producto>(productoDTO);
            producto.Id = Id;
            await _productoServices.ActualizarProducto(producto);
            return NoContent();

        }
        [HttpDelete("EliminarProducto/{Id:int}")]
        public async Task<ActionResult> EliminarProducto(int Id)
        {
            await _productoServices.EliminarProducto(Id);
            return Ok();
        }
    }
}
