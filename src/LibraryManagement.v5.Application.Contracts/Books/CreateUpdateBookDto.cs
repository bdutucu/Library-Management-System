using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.v5.Books;

public class CreateUpdateBookDto
{


    public Guid AuthorId { get; set; }


    [Required]
    [StringLength(128)]
    public string Name { get; set; } = string.Empty;

    [Required]
    public BookType Type { get; set; } = BookType.Undefined;

    [Required]
    [DataType(DataType.Date)]
    public DateTime PublishDate { get; set; } = DateTime.Now;



    [Required]
    [StringLength(128)]
    public string Shelf { get; set; } = string.Empty;
}