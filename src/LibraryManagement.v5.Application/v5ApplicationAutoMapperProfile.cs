using AutoMapper;
using LibraryManagement.v5.Authors;
using LibraryManagement.v5.Books;
using LibraryManagement.v5.Shelves;

namespace LibraryManagement.v5;

public class v5ApplicationAutoMapperProfile : Profile
{
    public v5ApplicationAutoMapperProfile()
    {
        CreateMap<Book, BookDto>();
        CreateMap<CreateUpdateBookDto, Book>();
        CreateMap<Author, AuthorDto>();
        CreateMap<Author, AuthorLookupDto>();

        CreateMap<Shelf, ShelfDto>();
        CreateMap<Shelf, ShelfLookupDto>();

        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
    }
}
