using StudentManagement_System_API.DTOS.RequestDtos;
using StudentManagement_System_API.DTOS.RequestDTOs;
using StudentManagement_System_API.DTOS.ResponseDtos;
using StudentManagement_System_API.DTOS.ResponseDTOs;
using StudentManagement_System_API.Entity;
using StudentManagement_System_API.IRepository;
using StudentManagement_System_API.IService;
using StudentManagement_System_API.Repository;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace StudentManagement_System_API.Service
{
    public class TimetableService : ITimetableService
    {
        private readonly ITimetableRepository _repository;

        public TimetableService(ITimetableRepository repository)
        {
            _repository = repository;
        }

        public async Task<TimetableResponceDTO> CreateTable(int courseId, TimetableRequestDtos timetableRequestDTO)
        {
            var timetable = new Timetable
            {
                Id = Guid.NewGuid(),
                CourseId = courseId,
                // Set the Date to current date without time (DateTime.Now.Date)
                Date = DateTime.Now.Date, // This will set the date as today's date with time = 00:00:00
                TimetableSubjects = timetableRequestDTO.Subjects?.Select(x => new TimetableSubject
                {
                    Name = x.SubjectName,
                    StartTime = x.StartTime,
                    EndTime = x.EndTime
                }).ToList()
            };

            var data = await _repository.CreateTimetableAsync(timetable);

            var req = new TimetableResponceDTO
            {
                Id = data.Id,
                CourseId = data.CourseId,
                timetablesubjectresponses = data.TimetableSubjects?.Select(x => new Timetablesubjectresponse
                {
                    Id = x.Id,
                    SubjectName = x.Name,
                    StartTime = x.StartTime,
                    EndTime = x.EndTime
                }).ToList()
            };

            return req; // Return the created timetable response
        }

          public async Task<TimetableResponceDTO> GetTimetableByDate(DateTime date)
        {
            // Use the Date property to remove the time and compare only the date part.
            var trimmedDate = date.Date;  

            // Pass the DateTime object (trimmedDate) to your repository method
            var data = await _repository.GetTimetableByDate(trimmedDate);

            if (data == null)
            {
                return null;  // Return null if no timetable data is found
            }

            // Map the data to the response DTO
            var res = new TimetableResponceDTO
            {
                Id = data.Id,
                CourseId = data.CourseId,
                timetablesubjectresponses = data.TimetableSubjects?.Select(x => new Timetablesubjectresponse
                {
                    Id = x.Id,
                    SubjectName = x.Name,
                    StartTime = x.StartTime,
                    EndTime = x.EndTime
                }).ToList()
            };

            return res;  // Return the mapped response
        }



        public async Task<TimetableResponceDTO> UpdateTimetable(DateTime date, TimetableRequestDtos timetableRequestDTO)
        {
            var timeTable = new Timetable
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
                TimetableSubjects = timetableRequestDTO.Subjects?.Select(x => new TimetableSubject

                {
                    Name = x.SubjectName,
                    StartTime = x.StartTime,
                    EndTime = x.EndTime
                }).ToList()
            };

            var data = await _repository.GetTimetableByDate(date);

            var resTable = new TimetableResponceDTO
            {
                Id = data.Id,
                CourseId = data.CourseId,
                timetablesubjectresponses = data.TimetableSubjects?.Select(x => new Timetablesubjectresponse
                {
                    SubjectName = x.Name,
                    StartTime = x.StartTime,
                    EndTime = x.EndTime
                }).ToList()
            };
            return resTable;
        }

        public async Task DeleteTable (DateTime date)
        {
            await _repository.DeleteTimetableByDate(date);
        }
        
    }
}
