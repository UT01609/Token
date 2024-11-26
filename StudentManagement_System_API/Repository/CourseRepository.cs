using StudentManagement_System_API.Entity;
using StudentManagement_System_API.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using StudentManagement_System_API.Database;

namespace StudentManagement_System_API.Repository
{
    public class CourseRepository : ICourseRepository
    {
       private readonly StudentManagementContext _studentManagementContext;

        public CourseRepository(StudentManagementContext studentManagementContext)
        {
            _studentManagementContext = studentManagementContext;
        }


        public async Task<Course> AddCourses (Course course)
        {
            var data = await _studentManagementContext.Courses.AddAsync (course);
            await _studentManagementContext.SaveChangesAsync();
            return course;
        }

        public async Task<List<Course>> GetallCourses ()
        {
            var data = await _studentManagementContext.Courses.Where(a =>!a.IsDeleted).Include(e => e.Enrollments).ToListAsync ();
            return data;
        }

        public async Task<Course> GetCourseById(int id)
        {
            var data = await _studentManagementContext.Courses.Include(e => e.Enrollments).FirstOrDefaultAsync (c => c.Id == id && !c.IsDeleted);
            return data;
        }

        public async Task<Course> UpadteCourse(Course course)
        {
            var data =  _studentManagementContext.Courses.Update (course);
            await _studentManagementContext.SaveChangesAsync ();
            return course;
        }

        public async Task DeleteCourse(int id)
        {
            var data = await GetCourseById(id);
            if (data != null)
            {
                data.IsDeleted = true;
                _studentManagementContext.Update(data);
                await _studentManagementContext.SaveChangesAsync();

            }
        }
    }
}
