using LibraryManagement.v5.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace LibraryManagement.v5.Shelves;

public class EfCoreShelfRepository
    : EfCoreRepository<v5DbContext, Shelf, Guid>,
        IShelfRepository
{
    public EfCoreShelfRepository(
        IDbContextProvider<v5DbContext> dbContextProvider)
        : base(dbContextProvider)
    {
    }

    public async Task<Shelf> FindByNameAsync(string name)
    {
        var dbSet = await GetDbSetAsync();
        return await dbSet.FirstOrDefaultAsync(shelf => shelf.Name == name);
    }

    public async Task<List<Shelf>> GetListAsync(
        int skipCount,
        int maxResultCount,
        string sorting,
        string filter = null)
    {
        var dbSet = await GetDbSetAsync();
        return await dbSet
            .WhereIf(
                !filter.IsNullOrWhiteSpace(),
                shelf => shelf.Name.Contains(filter)
                )
            .OrderBy(sorting)
            .Skip(skipCount)
            .Take(maxResultCount)
            .ToListAsync();
    }
}

