using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApiCatalogoProductos.DTOs;
using WebApiCatalogoProductos.Entities;

namespace WebApiCatalogoProductos.Controllers
{
    [Route("api/catalogoproductos")]
    [ApiController]
    public class GestionarProductosController : ControllerBase
    {
        private readonly ILogger<GestionarProductosController> logger;
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        
        public GestionarProductosController(ILogger<GestionarProductosController> logger, ApplicationDbContext dbContext, IMapper mapper)
        {
            this.logger = logger;
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        [HttpGet("ObtenerListadoProductos")]
        public async Task<ActionResult<List<ProductoDTO>>> ObtenerListadoProductos()
        {
            var queryable = dbContext.Generos.AsQueryable();
            var generos = await queryable.OrderBy(x => x.Nombre).ToListAsync();
            return mapper.Map<List<ProductoDTO>>(generos);
        }

        [HttpGet("ObtenerProductoPorId/{Id:int}")]
        public async Task<ActionResult<ProductoDTO>> ObtenerProductoPorId(int Id)
        {
            var genero = await dbContext.Generos.FirstOrDefaultAsync(x => x.Id == Id);

            if (genero == null)
            {
                return NotFound();
            }
            return mapper.Map<ProductoDTO>(genero);
        }

        [HttpPost("AgregarProducto")]
        public async Task<ActionResult> Post([FromBody] ProductoDTO productoDTO)
        {
            var producto = mapper.Map<Producto>(productoDTO);
            dbContext.Add(producto);
            await dbContext.SaveChangesAsync();
            return Ok(new { message = "Producto agregado correctamente" });
        }

        [HttpPut("EditarProducto")]
        public async Task<ActionResult> Put(int id, [FromBody] ProductoDTO productoDTO)
        {
            var producto = await dbContext.Productos.FirstOrDefaultAsync(x => x.Id == id);

            if (producto == null)
            {
                return NotFound();
            }
            producto = mapper.Map(productoDTO, producto);
            await dbContext.SaveChangesAsync();
            return NoContent();

        }
        [HttpDelete]
        public async Task<ActionResult> Delete()
        {
            throw new NotImplementedException();
        }
    }
}
