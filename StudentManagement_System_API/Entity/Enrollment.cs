namespace StudentManagement_System_API.Entity
{
    public class Enrollment
    {
        public int Id { get; set; }  // Primary Key
       
        public int CourseId { get; set; }  // Foreign Key from Course
        public DateTime EnrolledDate { get; set; }
     
       

     public Course course { get; set; }
      
    }

}
