using Application.Contracts.Repositories;
using Domain;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class CountGroupRepository : ICountGroup
    {
        private readonly CountGroupContext _context;

        public CountGroupRepository(CountGroupContext context)
        {
            _context = context;
        }

        public async Task<CountGroup> GetAsync(Guid guid) =>
            await _context.CountGroups.FirstOrDefaultAsync(group => group.Guid == guid);

        public async Task CreateAsync(Guid guid, string userName)
        {
            _context.CountGroups.Add(new CountGroup
            {
                Guid = guid,
                GroupMembers = new()
                {
                    new GroupMember
                    {
                        Name = userName,
                    }
                }
            });

            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(CountGroup countGroup)
        {
            var group = await _context.CountGroups.FirstOrDefaultAsync(x => x.Guid == countGroup.Guid);
            group.GroupMembers = countGroup.GroupMembers;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(CountGroup countGroup)
        {
            _context.CountGroups.Remove(countGroup);

            await _context.SaveChangesAsync();
        }
    }
}
