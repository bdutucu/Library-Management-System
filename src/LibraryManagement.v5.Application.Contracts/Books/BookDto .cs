using System;
using Volo.Abp.Application.Dtos;

namespace LibraryManagement.v5.Books;

public class BookDto : AuditedEntityDto<Guid>
{

    public Guid AuthorId { get; set; }
    public string AuthorName { get; set; }

    public Guid ShelfId { get; set; }
    public string ShelfName { get; set; }

    public string Name { get; set; }

    public BookType Type { get; set; }

    public DateTime PublishDate { get; set; }

    public string Shelf { get; set; }
}