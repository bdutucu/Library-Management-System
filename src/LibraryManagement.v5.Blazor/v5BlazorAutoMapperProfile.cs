using AutoMapper;
using LibraryManagement.v5.Authors;
using LibraryManagement.v5.Books;

namespace LibraryManagement.v5.Blazor;

public class v5BlazorAutoMapperProfile : Profile
{
    public v5BlazorAutoMapperProfile()
    {
        CreateMap<BookDto, CreateUpdateBookDto>();
        CreateMap<AuthorDto, UpdateAuthorDto>();

        //Define your AutoMapper configuration here for the Blazor project.
    }
}
