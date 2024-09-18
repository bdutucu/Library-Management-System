using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace LibraryManagement.v5.Books;

public class ShelfLookupDto : EntityDto<Guid>
{
    public string Name { get; set; }
}
