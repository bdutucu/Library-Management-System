using LibraryManagement.v5.Samples;
using Xunit;

namespace LibraryManagement.v5.EntityFrameworkCore.Applications;

[Collection(v5TestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<v5EntityFrameworkCoreTestModule>
{

}
