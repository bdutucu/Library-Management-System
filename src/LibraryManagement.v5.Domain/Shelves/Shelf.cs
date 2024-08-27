using LibraryManagement.v5.Authors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp;

namespace LibraryManagement.v5.Shelves;

public class Shelf : FullAuditedAggregateRoot<Guid>
{
    public string Name { get; private set; }
    public int Floor { get; set; }
    public string Building { get; set; }

    private Shelf()
    {
        /* This constructor is for deserialization / ORM purpose */
    }

    internal Shelf(
        Guid id,
        string name,
        int floor,
        string building) // eğer takılırsa buildingi nullable yap
        : base(id)
    {
        SetName(name);
        Floor = floor;
        Building = building;
    }

    internal Shelf ChangeName(string name)
    {
        SetName(name);
        return this;
    }

    private void SetName(string name)
    {
        Name = Check.NotNullOrWhiteSpace(
            name,
            nameof(name),
            maxLength: ShelfConsts.MaxNameLength
        );
    }
}
