using System.ComponentModel.DataAnnotations.Schema;

namespace HandinDatabases.Models;

public class Book
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Genre { get; set; }
    public int Pages { get; set; }
    
    public override bool Equals(object? obj)
    {
        return Equals(obj as Book);
    }

    private bool Equals(Book? book)
    {
        return book != null && book.Id == this.Id && book.Title == this.Title && book.Author == this.Author && book.Genre == this.Genre && book.Pages == this.Pages;
    }
}