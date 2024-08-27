﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace LibraryManagement.v5.Shelves;

public interface IShelfRepository : IRepository<Shelf, Guid>
{
    Task<Shelf> FindByNameAsync(string name);

    Task<List<Shelf>> GetListAsync(
        int skipCount,
        int maxResultCount,
        string sorting,
        string filter = null
    );
}
