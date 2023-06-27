using Services.Domain.Models;

namespace HiredServices.Domain.Models
{
    public class HiredService
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
        public string ScheduledDate { get; set; }
        public string Status { get; set; }
        
        public int CustomerId { get; set; }
        public int AgencyId { get; set; }
        
        public int ServiceId { get; set; }
        public Service Service { get; set; }
    }
}