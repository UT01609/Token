using Microsoft.EntityFrameworkCore;
using StudentManagement_System_API.Entity;

namespace StudentManagement_System_API.Database
{
    public class StudentManagementContext : DbContext
    {
        public StudentManagementContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Marks> Marks { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Timetable> Timetables { get; set; }
        public DbSet<TimetableSubject> TimetableSubjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure UserRole as an enum (stored as a string in the database)
            modelBuilder.Entity<User>()
                .Property(u => u.UserRole)
                .HasConversion(
                    v => v.ToString(),
                    v => (Role)Enum.Parse(typeof(Role), v));  // Convert enum to string when saving to the database and back

            // Many-to-many relationship between Student and Course via Enrollment
            //modelBuilder.Entity<Enrollment>()
            //    .HasKey(e => new { e.UTNumber, e.CourseId });

            //modelBuilder.Entity<Enrollment>()
            //    .HasOne(e => e.Student)
            //    .WithMany(s => s.Enrollments)
            //    .HasForeignKey(e => e.UTNumber);

            //modelBuilder.Entity<Enrollment>()
            //    .HasOne(e => e.Course)
            //    .WithMany(c => c.Enrollments)
            //    .HasForeignKey(e => e.CourseId);

            // One-to-many relationship between Course and Exam
            modelBuilder.Entity<Exam>()
                .HasOne(e => e.Course)
                .WithMany(c => c.Exams)
                .HasForeignKey(e => e.CourseId);

            // One-to-many relationship between Marks and Exam
            modelBuilder.Entity<Marks>()
                .HasOne(m => m.Exam)
                .WithMany(e => e.Marks)
                .HasForeignKey(m => m.ExamId);

            // One-to-many relationship between Marks and Student
            modelBuilder.Entity<Marks>()
                .HasOne(m => m.Student)
                .WithMany(s => s.Marks)
                .HasForeignKey(m => m.UTNumber);

            // One-to-many relationship between Timetable and Course
            modelBuilder.Entity<Timetable>()
                .HasOne(t => t.Course)
                .WithMany(c => c.Timetables)
                .HasForeignKey(t => t.CourseId);

            // One-to-many relationship between Attendance and Timetable
            //modelBuilder.Entity<Attendance>()
            //    .HasOne(a => a.Timetable)
            //    .WithMany(t => t.Attendances)
            //    .HasForeignKey(a => a.TimetableId);

            // One-to-many relationship between Attendance and Student
            modelBuilder.Entity<Attendance>()
                .HasOne(a => a.Student)
                .WithMany(s => s.Attendances)
                .HasForeignKey(a => a.UTNumber);


            modelBuilder.Entity<Course>()
                .HasMany(e =>e.Enrollments)
                .WithOne(c => c.course)
                .HasForeignKey(c => c.CourseId);

                


        }

        
    }
}