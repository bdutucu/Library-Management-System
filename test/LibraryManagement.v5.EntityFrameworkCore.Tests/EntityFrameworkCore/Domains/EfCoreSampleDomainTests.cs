using LibraryManagement.v5.Samples;
using Xunit;

namespace LibraryManagement.v5.EntityFrameworkCore.Domains;

[Collection(v5TestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<v5EntityFrameworkCoreTestModule>
{

}
