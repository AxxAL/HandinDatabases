using System.ComponentModel.DataAnnotations.Schema;

namespace HandinDatabases.Models;

public class Loan
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int BookId { get; set; }
    public int StudentId { get; set; }

    public override bool Equals(object? obj)
    {
        return Equals(obj as Loan);
    }

    private bool Equals(Loan? loan)
    {
        return loan != null && loan.Id == this.Id && loan.BookId == this.BookId && loan.StudentId == this.StudentId;
    }
}