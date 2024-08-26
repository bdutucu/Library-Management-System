using Xunit;

namespace LibraryManagement.v5.EntityFrameworkCore;

[CollectionDefinition(v5TestConsts.CollectionDefinitionName)]
public class v5EntityFrameworkCoreCollection : ICollectionFixture<v5EntityFrameworkCoreFixture>
{

}
