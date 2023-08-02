namespace Task1.Models;

public partial class Line
{
    public int Id { get; set; }

    public int FileId { get; set; }

    public DateTime Date { get; set; }

    public string EngLetters { get; set; } = null!;

    public string RuLetters { get; set; } = null!;

    public int RandomInt { get; set; }

    public double RandomFractional { get; set; }

    public virtual File File { get; set; } = null!;
}
