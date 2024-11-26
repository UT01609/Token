using StudentManagement_System_API.DTOS.RequestDTOs;
using StudentManagement_System_API.DTOS.ResponseDTOs;
using StudentManagement_System_API.Entity;
using StudentManagement_System_API.IRepository;
using StudentManagement_System_API.IService;

namespace StudentManagement_System_API.Service
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentrepository;
        public StudentService(IStudentRepository studentrepository) { 
            _studentrepository = studentrepository;
        }

        //public async Task<List<Student>> GetStudentsForAttendance(int courseId)
        //{
        //    var AttendanceList = new List<Student>();   
        //    var data = await _studentrepository.GetStudentsWithEnrollments();
        //    foreach (var student in data) {
        //        var enrollments = student.Enrollments.ToList();
        //        foreach (var enrollment in enrollments) {
        //            if (enrollment.CourseId == courseId) {
        //                AttendanceList.Add(student);
        //            }
        //        }
        //    }
        //    return AttendanceList;
        //}


        public async Task<StudentResponceDTO> GetStudentById(string utNumber)
        {
            var student = await _studentrepository.GetStudentById(utNumber);
            if (student == null)
            {
                return null;  // Handle not found case
            }
            return new StudentResponceDTO
            {
                UTNumber = student.UTNumber,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Email = student.Email,
                NICNumber = student.NICNumber,
                IsActive = student.IsActive,
                Batch = student.Batch,
                UserId = student.UserId
            };
        }


        public async Task<List<StudentResponceDTO>> GetAllStudent()
        {
            var students = await _studentrepository.GetAllStudent();
            return students.Select(student => new StudentResponceDTO
            {
                UTNumber = student.UTNumber,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Email = student.Email,
                NICNumber = student.NICNumber,
                IsActive=student.IsActive,
                Batch = student.Batch,
                UserId = student.UserId
            }).ToList();
        }


        public async Task<StudentResponceDTO> CreateStudent(StudentRequestDTO studentRequestDto)
        {
            var student = new Student
            {
                UTNumber = studentRequestDto.UTNumber,
                FirstName = studentRequestDto.FirstName,
                LastName = studentRequestDto.LastName,
                Email = studentRequestDto.Email,
                NICNumber = studentRequestDto.NICNumber,
                Batch = studentRequestDto.Batch,
                UserId = studentRequestDto.UserId
            };

            var createdStudent = await _studentrepository.CreateStudent(student);

            return new StudentResponceDTO
            {
                UTNumber = createdStudent.UTNumber,
                FirstName= createdStudent.FirstName,
                LastName = createdStudent.LastName,
                Email = createdStudent.Email,
                NICNumber = createdStudent.NICNumber,
                Batch = createdStudent.Batch,
                IsActive = createdStudent.IsActive,
                UserId = createdStudent.UserId
            };
        }

        public async Task<StudentResponceDTO> UpdateStudent(string utnumber,StudentRequestDTO studentRequestDto)
        {
            var student = new Student
            {
                UTNumber = studentRequestDto.UTNumber,
                Batch = studentRequestDto.Batch,
                FirstName= studentRequestDto.FirstName,
                LastName = studentRequestDto.LastName,
                Email = studentRequestDto.Email,
                NICNumber = studentRequestDto.NICNumber,
                UserId = studentRequestDto.UserId
            };

            var updatedStudent = await _studentrepository.UpdateStudent(utnumber);

            return new StudentResponceDTO
            {
                UTNumber = updatedStudent.UTNumber,
                FirstName = updatedStudent.FirstName,
                LastName = updatedStudent.LastName,
                Email = updatedStudent.Email,
                NICNumber = updatedStudent.NICNumber,
                IsActive= updatedStudent.IsActive,
                Batch = updatedStudent.Batch,
                UserId = updatedStudent.UserId
            };
        }

        public async Task<bool> DeleteStudent(string utNumber)
        {
            return await _studentrepository.DeleteStudent(utNumber);
        }

    }
}
