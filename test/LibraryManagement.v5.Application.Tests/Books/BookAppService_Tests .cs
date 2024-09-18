using System;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagement.v5.Authors;
using LibraryManagement.v5.Books;
using LibraryManagement.v5;
using Shouldly;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Modularity;
using Volo.Abp.Validation;
using Xunit;
using LibraryManagement.v5.Shelves;
namespace LibraryManagement.v5.Books;

public abstract class BookAppService_Tests<TStartupModule> : v5ApplicationTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{
    private readonly IBookAppService _bookAppService;

    private readonly IAuthorAppService _authorAppService;
    //authorda bunu ekledim

    private readonly IShelfAppService _shelfAppService;
    protected BookAppService_Tests()
    {
        _bookAppService = GetRequiredService<IBookAppService>();
        _authorAppService = GetRequiredService<IAuthorAppService>();
        //authorda bunu ekledim
        _shelfAppService = GetRequiredService<IShelfAppService>();
        //shelfte de bunu ekledim.
    }

    [Fact]
    public async Task Should_Get_List_Of_Books()
    {
        //Act
        var result = await _bookAppService.GetListAsync(
            new PagedAndSortedResultRequestDto()
        );

        //Assert
        result.TotalCount.ShouldBeGreaterThan(0);
        // result.Items.ShouldContain(b => b.Name == "1984"); authoru ekledikten sonra aşağıdaki gibi oldu. 
        /* result.Items.ShouldContain(b => b.Name == "1984" &&
                                        b.AuthorName == "George Orwell");   shelfi ekledikten sonra asagidaki gibi oldu        */
        result.Items.ShouldContain(b => b.Name == "1984" &&
                                        b.AuthorName == "George Orwell"  &&
                                        b.ShelfName == "a100");
    }

    [Fact]
    public async Task Should_Create_A_Valid_Book()
    {

        var authors = await _authorAppService.GetListAsync(new GetAuthorListDto());
        var shelves = await _shelfAppService.GetListAsync(new GetShelfListDto());
        //shelves icin bu ustteki ve alttaki eklendi.
        var firstAuthor = authors.Items.First();
        //authorsta bunu ekledim
        var firstShelf = shelves.Items.First();

        //Act
        var result = await _bookAppService.CreateAsync(
            new CreateUpdateBookDto
            {
                AuthorId = firstAuthor.Id,
                //authordan sonra bu geldi
                ShelfId = firstShelf.Id,
                //shelften sonra da bu geldi.
                Name = "New test book 42",
               // Author = "Bugrahan Dutucu",
                Shelf = "500t",
                PublishDate = DateTime.Now,
                Type = BookType.ScienceFiction
            }
        );

        //Assert
        result.Id.ShouldNotBe(Guid.Empty);
        result.Name.ShouldBe("New test book 42");
    }

    [Fact]
    public async Task Should_Not_Create_A_Book_Without_Name()
    {
        var exception = await Assert.ThrowsAsync<AbpValidationException>(async () =>
        {
            await _bookAppService.CreateAsync(
                new CreateUpdateBookDto
                {
                    Name = "",
                  //  Author = "Microsoft",
                    Shelf = "500t",
                    PublishDate = DateTime.Now,
                    Type = BookType.ScienceFiction
                }
            );
        });

        exception.ValidationErrors
            .ShouldContain(err => err.MemberNames.Any(mem => mem == "Name"));
    }
}