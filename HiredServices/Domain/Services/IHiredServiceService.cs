using HiredServices.Domain.Models;
using HiredServices.Domain.Services.Communication;

namespace HiredServices.Domain.Services
{
    public interface IHiredServiceService
    {
        Task<IEnumerable<HiredService>> ListAsync();
        Task<IEnumerable<HiredService>> FindByAgencyIdAsync(int agencyId);
        Task<IEnumerable<HiredService>> FindByCustomerIdAsync(int customerId);
        // Task<IEnumerable<HiredService>> FindByCustomerIdWithServiceInformationAsync(int customerId);
        Task<HideServiceResponse> SaveAsync(HiredService service);
        Task<HideServiceResponse> FindById(int id);
        Task<HideServiceResponse> UpdateAsync(int id, HiredService service);
        Task<HideServiceResponse> DeleteAsync(int id);
    }
}