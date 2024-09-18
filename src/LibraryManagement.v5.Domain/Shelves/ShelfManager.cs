using LibraryManagement.v5.Authors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;
using Volo.Abp.Guids;
using Volo.Abp;

namespace LibraryManagement.v5.Shelves;

public class ShelfManager : DomainService
{
    private readonly IShelfRepository _shelfRepository;

    public ShelfManager(IShelfRepository shelfRepository)
    {
        _shelfRepository = shelfRepository;
    }

    public async Task<Shelf> CreateAsync(
        string name,
        int floor,
        string building) // eğer takılırsa bu buildingi nullable yap 
    {
        Check.NotNullOrWhiteSpace(name, nameof(name));

        var existingShelf = await _shelfRepository.FindByNameAsync(name);
        if (existingShelf != null)
        {
            throw new ShelfAlreadyExistsException(name);
        }

        return new Shelf(
            GuidGenerator.Create(),
            name,
            floor,
            building
        );
    }

    public async Task ChangeNameAsync(
        Shelf shelf,
        string newName)
    {
        Check.NotNull(shelf, nameof(shelf));
        Check.NotNullOrWhiteSpace(newName, nameof(newName));

        var existingShelf = await _shelfRepository.FindByNameAsync(newName);
        if (existingShelf != null && existingShelf.Id != shelf.Id)
        {
            throw new ShelfAlreadyExistsException(newName);
        }

        shelf.ChangeName(newName);
    }
}
