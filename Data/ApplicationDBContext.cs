namespace BelleAPI.Data;
using BelleAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

public class ApplicationDBContext : DbContext
{
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
    {

    }

    public DbSet<Product> products { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<Transaction_item> Transaction_Items { get; set; }
    public DbSet<payment_detail> payment_Details { get; set; }
    public DbSet<payment_option> payment_Options { get; set; }
    public DbSet<customer> customers { get; set; }
    public DbSet<MedicalRecord> MedicalRecords { get; set; }
}