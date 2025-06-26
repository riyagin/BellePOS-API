using BelleAPI.Data;
using BelleAPI.Models;
using BelleAPI.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BelleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class productsController : ControllerBase
    {
        private readonly ApplicationDBContext dbContext;
        public productsController(ApplicationDBContext dBContext)
        {
            this.dbContext = dBContext;
        }
        [HttpGet]
        public IActionResult GetAllItems()
        {
            return Ok(dbContext.products.ToList());
        }

        [HttpPost]
        public async Task<IActionResult> AddItems(AddProductDto addItemDto)
        {
            var existingItem = await dbContext.products.FindAsync(addItemDto.kode_item);
            if (existingItem != null)
            {
                return BadRequest($"Item with kode_item '{addItemDto.kode_item}' already exists.");
            }

            var itemEntity = new Product()
            {
                kode_item = addItemDto.kode_item,
                nama_item = addItemDto.nama_item,
                jenis = addItemDto.jenis,
                satuan = addItemDto.satuan,
                harga = addItemDto.harga,
            };
            dbContext.products.Add(itemEntity);
            await dbContext.SaveChangesAsync();

            return Ok(itemEntity);

        }

        [HttpGet("search")]
        public IActionResult SearchItems([FromQuery] string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return BadRequest("Keyword is required.");
            }

            keyword = keyword.ToLower();

            var result = dbContext.products
                .Where(i =>
                    i.kode_item.ToLower().Contains(keyword) ||
                    i.nama_item.ToLower().Contains(keyword))
                .ToList();

            if (result.Count == 0)
            {
                return NotFound("No items found matching the keyword.");
            }

            return Ok(result);
        }


    }
}
