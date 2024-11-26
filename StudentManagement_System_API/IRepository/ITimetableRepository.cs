using StudentManagement_System_API.Entity;

namespace StudentManagement_System_API.IRepository
{
    public interface ITimetableRepository
    {
        Task<Timetable> CreateTimetableAsync(Timetable timetable);
        Task<Timetable> GetTimetableByDate(DateTime date);
        Task<Timetable> UpdateTimetableByDate(Timetable timetable);
        Task DeleteTimetableByDate(DateTime date);
        

    }
}
