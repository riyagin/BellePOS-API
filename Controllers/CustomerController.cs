using BelleAPI.Data;
using BelleAPI.Models;
using BelleAPI.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BelleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ApplicationDBContext dbContext;
        public CustomerController(ApplicationDBContext dBContext)
        {
            this.dbContext = dBContext;
        }

        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            return Ok(dbContext.customers.ToList());
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer(AddCustomerDto addCustomerDto)
        {
            if (string.IsNullOrWhiteSpace(addCustomerDto.name))
            {
                return BadRequest("Name is required to generate ID.");
            }
            var firstLetter = char.ToUpper(addCustomerDto.name.Trim()[0]);
            // Get all customer IDs starting with that letter
            var matchingCustomers = dbContext.customers
                .Where(c => c.id.StartsWith(firstLetter.ToString()))
                .Select(c => c.id)
                .ToList();

            // Extract numeric parts and find the max
            int maxNumber = 0;
            foreach (var id in matchingCustomers)
            {
                if (id.Length >= 6 && int.TryParse(id.Substring(1), out int number))
                {
                    if (number > maxNumber)
                        maxNumber = number;
                }
            }

            int nextNumber = maxNumber + 1;
            string newId = $"{firstLetter}{nextNumber.ToString("D5")}";

            var itemEntity = new customer()
            {
                id = addCustomerDto.id,
                name = addCustomerDto.name,
                phone = addCustomerDto.phone,
                address = addCustomerDto.address,
                NIK = addCustomerDto.NIK,
                tgl_lahir = addCustomerDto.tgl_lahir,
            };
            dbContext.customers.Add(itemEntity);
            await dbContext.SaveChangesAsync();

            return Ok(itemEntity);
        }

        [HttpGet("search")]
        public IActionResult SearchCustomers([FromQuery] string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return BadRequest("Keyword is required.");
            }

            keyword = keyword.ToLower();

            var result = dbContext.customers
                .Where(i =>
                    i.id.Contains(keyword) ||
                    i.name.ToLower().Contains(keyword) ||
                    i.address.ToLower().Contains(keyword) ||
                    i.phone.Contains(keyword))
                .ToList();

            if (result.Count == 0)
            {
                return NotFound("No items found matching the keyword.");
            }

            return Ok(result);
        }
    }
}
