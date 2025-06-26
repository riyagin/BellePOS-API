using BelleAPI.Data;
using BelleAPI.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BelleAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicalRecordsController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public MedicalRecordsController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: /api/medicalrecords
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var records = await _context.MedicalRecords.ToListAsync();
            return Ok(records);
        }

        // GET: /api/medicalrecords/customer/C001
        [HttpGet("customer/{customerId}")]
        public async Task<IActionResult> GetByCustomer(string customerId)
        {
            var records = await _context.MedicalRecords
                .Where(m => m.Customer_ID == customerId)
                .ToListAsync();

            if (records.Count == 0)
                return NotFound("No medical records found for this customer.");

            return Ok(records);
        }

        // POST: /api/medicalrecords
        [HttpPost]
        public async Task<IActionResult> Add(MedicalRecord newRecord)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Optionally generate ID here if needed

            _context.MedicalRecords.Add(newRecord);
            await _context.SaveChangesAsync();

            return Ok(newRecord);
        }
    }
}
