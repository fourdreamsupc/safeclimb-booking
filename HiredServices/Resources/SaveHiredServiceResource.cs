using System.ComponentModel.DataAnnotations;

namespace HiredServices.Resources
{
    public class SaveHiredServiceResource
    {
        [Required]
        public int CustomerId { get; set; }
    
        [Required]
        public int AgencyId { get; set; }
        
        [Required]
        public int ServiceId { get; set; }
        
        [Required]
        public int Amount { get; set; }
        
        [Required]
        public double Price { get; set; }
        
        [Required]
        [MaxLength(15)]
        public string ScheduledDate { get; set; }
        
        [Required]
        [MaxLength(30)]
        public string Status { get; set; }
    }
}