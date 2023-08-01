using System;
using System.Collections.Generic;

namespace Task1.Models;

public partial class File
{
    public int FileId { get; set; }

    public string FileName { get; set; } = null!;

    public virtual ICollection<Line> Lines { get; set; } = new List<Line>();
}
