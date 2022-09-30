namespace WebAPI.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;
        public string? Description { get; set; }
        public virtual ICollection<Product>? Products { get; set; }
    }
    //public class Student
    //{
    //    public int StudentId { get; set; }
    //    public string FirstName { get; set; }
    //    public string LastName { get; set; }
    //    public virtual ICollection<StudentCourses> Courses { get; set; }

    //}
    //public class Course
    //{
    //    public int CurseId { get; set; }
    //    public string Name { get; set; }
    //    public virtual ICollection<StudentCourses> Students { get; set; }
    //}
    //public class StudentCourses
    //{
    //    public int StudentId { get; set; }
    //    public Student Student { get; set; }
    //    public int CourseId { get; set; }
    //    public Course Course { get; set; }
    //}
}
