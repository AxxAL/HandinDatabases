using System.ComponentModel.DataAnnotations.Schema;

namespace HandinDatabases.Models;

public class Course
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Title { get; set; }
    
    public virtual ICollection<Enrollment> Enrollments { get; set; }

    public override bool Equals(object? obj)
    {
        return Equals(obj as Student);
    }

    private bool Equals(Course? course)
    {
        return course != null && course.Id == this.Id && course.Title == this.Title;
    }
}