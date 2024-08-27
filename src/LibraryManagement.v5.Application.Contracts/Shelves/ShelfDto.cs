using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace LibraryManagement.v5.Shelves;

public class ShelfDto : EntityDto<Guid>
{
    public string Name { get; set; }

    public int Floor { get; set; }

    public string Building { get; set; }
}
