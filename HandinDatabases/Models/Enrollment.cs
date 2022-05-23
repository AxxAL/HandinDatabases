using System.ComponentModel.DataAnnotations.Schema;

namespace HandinDatabases.Models;

public enum Grade
{
    A,
    B,
    C,
    D,
    E,
    F
}

public class Enrollment
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int StudentId { get; set; }
    public int CourseId { get; set; }
    
    public Grade? Grade { get; set; }

    public override bool Equals(object? obj)
    {
        return Equals(obj as Enrollment);
    }

    private bool Equals(Enrollment? enrollment)
    {
        return enrollment != null && enrollment.Id == this.Id && enrollment.CourseId == this.CourseId && enrollment.StudentId == this.StudentId;
    }
}