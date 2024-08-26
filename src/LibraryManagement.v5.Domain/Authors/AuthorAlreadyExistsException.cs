using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace LibraryManagement.v5.Authors;
public class AuthorAlreadyExistsException : BusinessException
{
    public AuthorAlreadyExistsException(string name)
        : base(v5DomainErrorCodes.AuthorAlreadyExists)
    {
        WithData("name", name);
    }
}
