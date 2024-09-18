using LibraryManagement.v5.Authors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace LibraryManagement.v5.Shelves;

public interface IShelfAppService : IApplicationService
{
    Task<ShelfDto> GetAsync(Guid id);

    Task<PagedResultDto<ShelfDto>> GetListAsync(GetShelfListDto input);

    Task<ShelfDto> CreateAsync( CreateShelfDto input);

    Task UpdateAsync(Guid id, UpdateShelfDto input);

    Task DeleteAsync(Guid id);
}
