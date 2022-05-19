using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Application.Contracts.Repositories
{
    public interface ICountGroup
    {
        Task CreateAsync(Guid guid, string userName);
        Task DeleteAsync(Domain.CountGroup countGroup);
        Task<Domain.CountGroup?> GetAsync(Guid guid);
        Task UpdateAsync(Domain.CountGroup countGroup);
    }
}
