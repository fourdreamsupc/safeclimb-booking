﻿using Services.Domain.Models;
using Services.Domain.Services.Communication;

namespace Services.Domain.Services
{
    public interface IServiceService
    {
        Task<IEnumerable<Service>> ListAsync();
        Task<ServiceResponse> GetById(int id);
        Task<IEnumerable<Service>> ListByAgencyId(int agencyId);
        Task<IEnumerable<Service>> ListByText(string name, int start, int limit);
        Task<IEnumerable<Service>> ListByTextAndFilterMoney(string name, int minMoney, int maxMoney, int start, int limit);
        Task<IEnumerable<Service>> ListByTextAndFilterScore(string name, int score, int start, int limit);
        Task<IEnumerable<Service>> ListByTextAndAllFilter(string name, int score, int min, int max, int start, int limit);
        Task<IEnumerable<Service>> FilterByCategory(string name, int start, int limit);
        Task<ServiceResponse> SaveAsync(Service service);
        Task<ServiceResponse> UpdateAsync(int id, Service service);
        Task<ServiceResponse> DeleteAsync(int id);
    }
}