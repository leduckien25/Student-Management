using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace WebMVC.Models
{
    public class StudentRepository : Repository
    {
        public StudentRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public IEnumerable<Student> GetStudents()
        {
            using IDbConnection connection = new SqlConnection(connectionString);
            return connection.Query<Student>("SELECT * FROM Student");
        }
        public int Add(Student student)
        {
            using IDbConnection connection = new SqlConnection(connectionString);
            return connection.Execute("INSERT INTO Student(Name, Gender, DateOfBirth, GPA, imageUrl) VALUES (@Name, @Gender, @DateOfBirth, @GPA, @imageUrl)", student);
        }
        public Student GetStudent(int id)
        {
            using IDbConnection connection = new SqlConnection(connectionString);
            return connection.QuerySingleOrDefault<Student>("SELECT * FROM Student WHERE StudentId = @StudentId", new { StudentId = id });
        }
        public int Edit(Student student)
        {
            using IDbConnection connection = new SqlConnection(connectionString);
            return connection.Execute("UPDATE Student SET Name = @Name, Gender = @Gender, DateOfBirth = @DateOfBirth, GPA = @GPA, imageUrl = @imageUrl WHERE StudentId = @StudentId", student);
        }
        public int Delete(int id)
        {
            using IDbConnection connection = new SqlConnection(connectionString);
            return connection.Execute("DELETE FROM Student WHERE StudentId = @StudentId", new { StudentId = id });
        }


    }
}
