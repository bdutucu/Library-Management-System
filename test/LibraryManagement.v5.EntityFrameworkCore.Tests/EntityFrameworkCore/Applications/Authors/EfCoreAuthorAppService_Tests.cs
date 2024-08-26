using LibraryManagement.v5.Authors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LibraryManagement.v5.EntityFrameworkCore.Applications.Authors;

[Collection(v5TestConsts.CollectionDefinitionName)]
public class EfCoreAuthorAppService_Tests : AuthorAppService_Tests<v5EntityFrameworkCoreTestModule>
{

}
