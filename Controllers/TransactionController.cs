using BelleAPI.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BelleAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ItemsController : ControllerBase
    {
        // Mock data for demo; replace with your DB context
        private static readonly List<items> ItemsList = new List<items>
        {
            new items { kode_item = "A001", keterangan = "Item A", satuan = "pcs", harga = 1000 },
            new items { kode_item = "B002", keterangan = "Item B", satuan = "box", harga = 2000 },
            new items { kode_item = "C003", keterangan = "Special C item", satuan = "pcs", harga = 3000 },
        };

        [HttpGet("search")]
        public ActionResult<List<items>> SearchItems([FromQuery] string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
            {
                return BadRequest("Keyword is required.");
            }

            var result = ItemsList
                .Where(i =>
                    (!string.IsNullOrEmpty(i.kode_item) && i.kode_item.Contains(keyword, StringComparison.OrdinalIgnoreCase)) ||
                    (!string.IsNullOrEmpty(i.keterangan) && i.keterangan.Contains(keyword, StringComparison.OrdinalIgnoreCase)))
                .ToList();

            return Ok(result);
        }
    }
}

