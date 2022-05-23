using System.ComponentModel.DataAnnotations.Schema;

namespace HandinDatabases.Models;

public class Student
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
   
    public ICollection<Enrollment> Enrollments { get; set; }
    public ICollection<Loan> Loans { get; set; }
    
    public override bool Equals(object? obj)
    {
        return Equals(obj as Student);
    }

    private bool Equals(Student? student)
    {
        return student != null && student.Id == this.Id && student.LastName == this.LastName;
    }
}