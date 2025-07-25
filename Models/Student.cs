namespace WebMVC.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public bool Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal GPA { get; set; }
        public string? imageUrl { get; set; }
    }
}
