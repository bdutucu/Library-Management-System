using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace LibraryManagement.v5.Shelves;

public class ShelfAlreadyExistsException : BusinessException
{
    public ShelfAlreadyExistsException(string name)
        : base(v5DomainErrorCodes.ShelfAlreadyExists)
    {
        WithData("name", name);
    }
}
