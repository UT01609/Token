using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagement_System_API.IService;
using StudentManagement_System_API.Service;

namespace StudentManagement_System_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarksControllers : ControllerBase
    {
        private readonly IMarksService _marksService;

        public MarksControllers(IMarksService marksService)
        {
            _marksService = marksService;
        }
    }
}
