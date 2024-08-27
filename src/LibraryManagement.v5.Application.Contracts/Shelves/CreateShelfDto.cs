using LibraryManagement.v5.Authors;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.v5.Shelves;

public class CreateShelfDto
{
    [Required]
    [StringLength(ShelfConsts.MaxNameLength)]
    public string Name { get; set; } = string.Empty;

    [Required]
    public int Floor { get; set; }

    public string Building { get; set; }
}