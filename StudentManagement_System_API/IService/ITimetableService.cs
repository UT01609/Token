using StudentManagement_System_API.DTOS.RequestDtos;
using StudentManagement_System_API.DTOS.RequestDTOs;
using StudentManagement_System_API.DTOS.ResponseDtos;

namespace StudentManagement_System_API.IService
{
    public interface ITimetableService
    {
        Task<TimetableResponceDTO> CreateTable(int courseId, TimetableRequestDtos timetableRequestDTO);
        Task<TimetableResponceDTO> GetTimetableByDate(DateTime date);
        Task<TimetableResponceDTO> UpdateTimetable(DateTime date, TimetableRequestDtos timetableRequestDTO);
       Task DeleteTable(DateTime date);

    }
}
