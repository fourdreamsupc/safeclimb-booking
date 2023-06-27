using HiredServices.Domain.Models;
using HiredServices.Domain.Repositories;
using Shared.Persistence.Contexts;
using Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HiredServices.Persistence.Repositories
{
    public class HiredServiceRepository : BaseRepository, IHiredServiceRepository
    {
        public HiredServiceRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<HiredService>> ListAsync()
        {
            return await _context.HiredServices.ToListAsync();
        }

        public async Task AddAsync(HiredService service)
        {
            await _context.AddAsync(service);
        }

        public async Task<HiredService> FindByIdAsync(int id)
        {
            return await _context.HiredServices.FindAsync(id);
        }
        
        public async Task<IEnumerable<HiredService>> FindByAgencyIdAsync(int agencyId)
        {
            return await _context.HiredServices
                .Where(p => p.AgencyId == agencyId)
                .ToListAsync();
        }

        public async Task<IEnumerable<HiredService>> FindByCustomerIdAsync(int customerId)
        {
            return await _context.HiredServices.Where(p => p.CustomerId == customerId).ToListAsync();
        }
        
        // public async Task<IEnumerable<HiredService>> FindByCustomerIdWithServiceInformationAsync(int customerId)
        // {
        //     return await _context.HiredServices
        //         .Where(p => p.CustomerId == customerId)
        //         .Include(s => s.Service)
        //         .ToListAsync();
        // }

        public void Update(HiredService service)
        {
            _context.HiredServices.Update(service);
        }

        public void Remove(HiredService service)
        {
            _context.HiredServices.Remove(service);
        }
    }
}