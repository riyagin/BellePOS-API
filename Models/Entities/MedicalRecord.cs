using System.ComponentModel.DataAnnotations;

namespace BelleAPI.Models.Entities
{
    public class MedicalRecord
    {
        [Key]
        public int Id { get; set; }
        public required string Customer_ID { get; set; }
        public string Subjective { get; set; }
        public string Objective { get; set; }
        public string Assessmment { get; set; }
        public string Plan { get; set; }
        public DateOnly VisitDate { get; set; }
        public DateTime CreationDate { get; set; }

    }
}
