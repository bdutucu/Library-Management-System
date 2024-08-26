using LibraryManagement.v5.Books;
using LibraryManagement.v5.EntityFrameworkCore;
using LibraryManagement.v5;
using Xunit;

namespace LibraryManagement.v5.EntityFrameworkCore.Applications.Books;

[Collection(v5TestConsts.CollectionDefinitionName)]
public class EfCoreBookAppService_Tests : BookAppService_Tests<v5EntityFrameworkCoreTestModule>
{

}