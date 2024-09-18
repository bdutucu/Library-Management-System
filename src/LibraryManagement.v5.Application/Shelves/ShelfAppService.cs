using LibraryManagement.v5.Authors;
using LibraryManagement.v5.Permissions;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace LibraryManagement.v5.Shelves;

[Authorize(v5Permissions.Shelves.Default)]
public class ShelfAppService : v5AppService, IShelfAppService
{
    private readonly IShelfRepository _shelfRepository;
    private readonly ShelfManager _shelfManager;

    public ShelfAppService(
        IShelfRepository shelfRepository,
        ShelfManager shelfManager)
    {
        _shelfRepository = shelfRepository;
        _shelfManager = shelfManager;
    }

    //...SERVICE METHODS WILL COME HERE...

    public async Task<ShelfDto> GetAsync(Guid id)
    {
        var shelf = await _shelfRepository.GetAsync(id);
        return ObjectMapper.Map<Shelf, ShelfDto>(shelf);
    }


    public async Task<PagedResultDto<ShelfDto>> GetListAsync(GetShelfListDto input)
    {
        if (input.Sorting.IsNullOrWhiteSpace())
        {
            input.Sorting = nameof(Shelf.Name);
        }

        var shelves = await _shelfRepository.GetListAsync(
            input.SkipCount,
            input.MaxResultCount,
            input.Sorting,
            input.Filter
        );

        var totalCount = input.Filter == null
            ? await _shelfRepository.CountAsync()
            : await _shelfRepository.CountAsync(
                shelf => shelf.Name.Contains(input.Filter));

        return new PagedResultDto<ShelfDto>(
            totalCount,
            ObjectMapper.Map<List<Shelf>, List<ShelfDto>>(shelves)
        );
    }


    [Authorize(v5Permissions.Shelves.Create)]
    public async Task<ShelfDto> CreateAsync(CreateShelfDto input)
    {
        var shelf = await _shelfManager.CreateAsync(
            input.Name,
            input.Floor,
            input.Building
        );

        await _shelfRepository.InsertAsync(shelf);

        return ObjectMapper.Map<Shelf, ShelfDto>(shelf);
    }

    [Authorize(v5Permissions.Shelves.Edit)]
    [Authorize(v5Permissions.Shelves.Edit)]
    public async Task UpdateAsync(Guid id, UpdateShelfDto input)
    {
        var shelf = await _shelfRepository.GetAsync(id);

        if (shelf.Name != input.Name)
        {
            await _shelfManager.ChangeNameAsync(shelf, input.Name);
        }

        shelf.Floor = input.Floor;
        shelf.Building = input.Building;

        await _shelfRepository.UpdateAsync(shelf);
    }

    [Authorize(v5Permissions.Shelves.Delete)]
    public async Task DeleteAsync(Guid id)
    {
        await _shelfRepository.DeleteAsync(id);
    }

}

