using HandinDatabases.Models;

namespace HandinDatabases;

public class SchoolService
{
    private readonly SchoolContext context;
    
    public SchoolService(SchoolContext context)
    {
        this.context = context;
    }
    
    // Queries database for student with given id and returns it.
    public Student GetStudentById(int id)
    {
        Student? student = context.Students.Find(id);
        
        if (student == null)
        {
            throw new KeyNotFoundException("Student with given id not found.");
        }
        
        return student;
    }
    
    // Gets all saved students from database.
    public ICollection<Student> GetAllStudents()
    {
        return context.Students.ToList();
    }

    // Saves given user to database.
    public Student AddStudent(Student student)
    {
        context.Students.Add(student);
        context.SaveChanges();

        return student;
    }
    
    // Updates given student in database.
    public Student UpdateStudent(Student student)
    {
        context.Students.Update(student);
        context.SaveChanges();

        return student;
    }
    
    // Deletes student with given id from database.
    public Student DeleteStudent(int id)
    {
        Student student;
        try
        {
            student = GetStudentById(id);
        } catch (KeyNotFoundException)
        {
            throw new KeyNotFoundException("Student with given id not found.");
        }
        
        context.Students.Remove(student);
        context.SaveChanges();

        return student;
    }
    
    // Queries database for course with given id and returns it.
    public Course GetCourseById(int id)
    {
        Course? course = context.Courses.Find(id);
        
        if (course == null)
        {
            throw new KeyNotFoundException("Course with given id not found.");
        }
        
        return course;
    }
    
    // Gets all saved courses from database.
    public ICollection<Course> GetAllCourses()
    {
        return context.Courses.ToList();
    }
    
    // Saves given course to database.
    public Course AddCourse(Course course)
    {
        context.Courses.Add(course);
        context.SaveChanges();

        return course;
    }
    
    // Updates given course in database.
    public Course UpdateCourse(Course course)
    {
        context.Courses.Update(course);
        context.SaveChanges();

        return course;
    }
    
    // Deletes course with given id from database.
    public Course DeleteCourse(int id)
    {
        Course course;
        try
        {
            course = GetCourseById(id);
        } catch (KeyNotFoundException)
        {
            throw new KeyNotFoundException("Course with given id not found.");
        }
        
        context.Courses.Remove(course);
        context.SaveChanges();

        return course;
    }
    
    // Queries database for enrollment with given id and returns it.
    public Enrollment GetEnrollmentById(int id)
    {
        Enrollment? enrollment = context.Enrollments.Find(id);
        
        if (enrollment == null)
        {
            throw new KeyNotFoundException("Enrollment with given id not found.");
        }
        
        return enrollment;
    }
    
    // Gets all saved enrollments from database.
    public ICollection<Enrollment> GetAllEnrollments()
    {
        return context.Enrollments.ToList();
    }
    
    // Saves given enrollment to database.
    public Enrollment AddEnrollment(Enrollment enrollment)
    {
        context.Enrollments.Add(enrollment);
        context.SaveChanges();

        return enrollment;
    }
    
    // Updates given enrollment in database.
    public Enrollment UpdateEnrollment(Enrollment enrollment)
    {
        context.Enrollments.Update(enrollment);
        context.SaveChanges();

        return enrollment;
    }
    
    // Deletes enrollment with given id from database.
    public Enrollment DeleteEnrollment(int id)
    {
        Enrollment enrollment;
        try
        {
            enrollment = GetEnrollmentById(id);
        } catch (KeyNotFoundException)
        {
            throw new KeyNotFoundException("Enrollment with given id not found.");
        }
        
        context.Enrollments.Remove(enrollment);
        context.SaveChanges();

        return enrollment;
    }
    
    // Queries database for book with given id and returns it.
    public Book GetBookById(int id)
    {
        Book? book = context.Books.Find(id);
        
        if (book == null)
        {
            throw new KeyNotFoundException("Book with given id not found.");
        }
        
        return book;
    }
    
    // Gets all saved books from database.
    public ICollection<Book> GetAllBooks()
    {
        return context.Books.ToList();
    }

    // Saves given book to database.
    public Book AddBook(Book book)
    {
        context.Books.Add(book);
        context.SaveChanges();

        return book;
    }

    // Updates given book in database.
    public Book UpdateBook(Book book)
    {
        context.Books.Update(book);
        context.SaveChanges();

        return book;
    }
    
    // Deletes book with given id from database.
    public Book DeleteBook(int id)
    {
        Book book;
        try
        {
            book = GetBookById(id);
        } catch (KeyNotFoundException)
        {
            throw new KeyNotFoundException("Book with given id not found.");
        }
        
        context.Books.Remove(book);
        context.SaveChanges();

        return book;
    }
    
    // Queries database for loan with given id and returns it.
    public Loan GetLoanById(int id)
    {
        Loan? loan = context.Loans.Find(id);
        
        if (loan == null)
        {
            throw new KeyNotFoundException("Loan with given id not found.");
        }
        
        return loan;
    }
    
    // Gets all saved loans from database.
    public ICollection<Loan> GetAllLoans()
    {
        return context.Loans.ToList();
    }

    // Saves given loan to database.
    public Loan AddLoan(Loan loan)
    {
        context.Loans.Add(loan);
        context.SaveChanges();

        return loan;
    }

    // Updates given loan in database.
    public Loan UpdateLoan(Loan loan)
    {
        context.Loans.Update(loan);
        context.SaveChanges();

        return loan;
    }

    // Deletes loan with given id from database.
    public Loan DeleteLoan(int id)
    {
        Loan loan;
        try
        {
            loan = GetLoanById(id);
        }
        catch (KeyNotFoundException)
        {
            throw new KeyNotFoundException("Loan with given id not found.");
        }

        context.Loans.Remove(loan);
        context.SaveChanges();

        return loan;
    }
}