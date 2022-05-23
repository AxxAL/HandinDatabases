using HandinDatabases.Models;

namespace HandinDatabases;

public class Menu
{
    private SchoolService schoolService = new SchoolService(new SchoolContext());

    private string[] mainMenu = new string[]
    {
        "1. Manage data.",
        "2. Search data.",
        "3. Exit."
    };

    private string[] dataSearchMenu = new string[]
    {
        "1. List all students.",
        "2. List all courses.",
        "3. List all enrollments.",
        "4. Students in course.",
        "5. Student's courses.",
        "6. List all loans."
    };
    
    private string[] dataManagementMenu = new string[]
    {
        "1. Create a new student.",
        "2. Remove a student.",
        "3. Create new course.",
        "4. Remove a course.",
        "5. Create new enrollment.",
        "6. Remove enrollment.",
        "7. Create a new loan."
    };
    
    private void PrintMenu(string[] menu)
    {
        foreach (string line in menu)
        {
            Console.WriteLine(line);
        }
    }

    private int activeMenu = 1;
    public void Run()
    {
        while (activeMenu != 0)
        {
            if (activeMenu == 1) MainMenu();
            if (activeMenu == 2) DataManagementMenu();
            if (activeMenu == 3) DataSearchMenu();
        }
    }

    private void MainMenu()
    {
        Console.Clear();
        PrintMenu(mainMenu);
        Console.Write("Please select an option: ");
        int selection = int.Parse(Console.ReadLine());

        switch (selection)
        {
            case 1:
                activeMenu = 2;
                break;
            case 2:
                activeMenu = 3;
                break;
            case 3:
                activeMenu = 0;
                break;
            default:
                Console.WriteLine("Invalid selection.");
                Pause();
                break;
        }
    }

    private void DataManagementMenu()
    {
        Console.Clear();
        PrintMenu(dataManagementMenu);
        Console.Write("Please select an option: ");
        int selection = int.Parse(Console.ReadLine());

        switch (selection)
        {
            case 1:
                Console.Write("Please specify the students full name: ");
                string[] studentName = Console.ReadLine().Split(" ");
                Student newStudent = new Student
                {
                    FirstName = studentName[0],
                    LastName = studentName[1]
                };
                schoolService.AddStudent(newStudent);
                Console.WriteLine($"Created student: { newStudent.FirstName } { newStudent.LastName }.");
                Pause();
                break;
            case 2:
                foreach (Student s in schoolService.GetAllStudents())
                {
                    Console.WriteLine($"{ s.Id } { s.FirstName } { s.LastName }");
                }
                
                Console.Write("Specify the id of the student to be removed: ");
                int studentId = int.Parse(Console.ReadLine());
                Student deletedStudent = schoolService.DeleteStudent(studentId);
                Console.WriteLine($"Deleted student: { deletedStudent.FirstName } { deletedStudent.LastName}");
                Pause();
                break;
            case 3:
                Console.Write("Please specify the title of the new course: ");
                string courseName = Console.ReadLine();
                Course newCourse = new Course
                {
                    Title = courseName
                };
                schoolService.AddCourse(newCourse);
                Console.WriteLine($"Created a new course: { newCourse.Title }");
                Pause();
                break;
            case 4:
                foreach (Course c in schoolService.GetAllCourses())
                {
                    Console.WriteLine($"{ c.Id } { c.Title }");
                }
                
                Console.Write("Specify the id of the course to be removed: ");
                int courseId = int.Parse(Console.ReadLine());
                Course deletedCourse = schoolService.DeleteCourse(courseId);
                Console.WriteLine($"Deleted course: { deletedCourse.Title }");
                Pause();
                break;
            case 5:
                Console.Write("Please specify the id of the student: ");
                int stId = int.Parse(Console.ReadLine());
                Console.Write("Please specify the id of the course: ");
                int coId = int.Parse(Console.ReadLine());
                Console.Write("Enrollment grade (Leave empty if not set yet): ");
                Enum.TryParse(Console.ReadLine(), out Grade grade);
                
                Enrollment newEnrollment = new Enrollment
                {
                    StudentId = stId,
                    CourseId = coId,
                    Grade = grade
                };

                schoolService.AddEnrollment(newEnrollment);
                Console.WriteLine($"Created a new enrollment: { newEnrollment.Id } Student: { newEnrollment.StudentId} Course: { newEnrollment.CourseId }");
                Pause();
                break;
            case 6:
                foreach (Enrollment e in schoolService.GetAllEnrollments())
                {
                    Console.WriteLine($"{ e.Id } StudentId: { e.StudentId } CourseId: { e.CourseId } Grade: { e.Grade }");
                }

                Console.Write("Please specify the id of the enrollment to be removed: ");
                int removedCourseId = int.Parse(Console.ReadLine());
                Enrollment deletedEnrollment = schoolService.DeleteEnrollment(removedCourseId);
                Console.WriteLine($"Deleted enrollment: { deletedEnrollment.Id }");
                Pause();
                break;
            case 7:
                foreach (Book book in schoolService.GetAllBooks())
                {
                    Console.WriteLine($"Id: { book.Id } Title: { book.Title } Author: { book.Author } Genres: {  book.Genre }");
                }
                Console.Write("Please specify the id of the book to be loaned: ");
                int bId = int.Parse(Console.ReadLine());
                Console.Write("Please specify the id of the student to add the loan: ");
                int sId = int.Parse(Console.ReadLine());

                Loan newLoan = new Loan
                {
                    BookId = bId,
                    StudentId = sId
                };

                schoolService.AddLoan(newLoan);
                Console.WriteLine($"Created a new loan: { newLoan.Id } Book Id: { newLoan.BookId } Student Id: { newLoan.StudentId }");
                Pause();
                break;
            default:
                Console.WriteLine("Invalid selection.");
                Pause();
                break;
        }

        activeMenu = 1;
    }

    private void DataSearchMenu()
    {
        Console.Clear();
        PrintMenu(dataSearchMenu);
        Console.Write("Please select an option: ");
        int selection = int.Parse(Console.ReadLine());

        switch (selection)
        {
            case 1:
                foreach (Student s in schoolService.GetAllStudents())
                {
                    Console.WriteLine($"{ s.Id } { s.FirstName } { s.LastName }");
                }
                Pause();
                break;
            case 2:
                foreach (Course c in schoolService.GetAllCourses())
                {
                    Console.WriteLine($"{ c.Id } { c.Title }");
                }
                Pause();
                break;
            case 3:
                foreach (Enrollment e in schoolService.GetAllEnrollments())
                {
                    Console.WriteLine($"{ e.Id } Student Id: { e.StudentId } Course Id: { e.CourseId } Grade: { e.Grade }");
                }
                Pause();
                break;
            case 5:
                foreach (Student s in schoolService.GetAllStudents())
                {
                    Console.WriteLine($"{ s.Id } { s.FirstName } { s.LastName }");
                }

                Console.Write("Please specify the id of the student to search: ");
                int sId = int.Parse(Console.ReadLine());
                Student student = schoolService.GetStudentById(sId);

                foreach (Enrollment enrollment in student.Enrollments)
                {
                    Console.WriteLine($"{ enrollment.Id } Course Id: { enrollment.CourseId } Grade: { enrollment.Grade }");
                }
                Pause();
                break;
            case 6:
                foreach (Loan loan in schoolService.GetAllLoans())
                {
                    Console.WriteLine($"{ loan.Id } Book Id: { loan.BookId } Student Id: { loan.StudentId }");
                }
                Pause();
                break;
            default:
                Console.WriteLine("Invalid selection.");
                Pause();
                break;
        }

        activeMenu = 1;
    }

    private void Pause()
    {
        Console.WriteLine("Press any key to continue...");
        Console.ReadLine();
    }
}