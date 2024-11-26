//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using StudentManagement_System_API.Entity;
//using StudentManagement_System_API.IService;
//using StudentManagement_System_API.Service;

//namespace StudentManagement_System_API.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ExamControllers : ControllerBase
//    {
//        private readonly ExamService _examService;

//        public ExamControllers(IExamService examService)
//        {
//            _examService = examService;
//        }

//        // GET: api/exams
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<Exam>>> GetAll()
//        {
//            var exams = await _examService.GetAllAsync();
//            return Ok(exams);
//        }

//        // GET: api/exams/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<Exam>> GetById(int id)
//        {
//            var exam = await _examService.GetByIdAsync(id);
//            if (exam == null)
//            {
//                return NotFound();
//            }
//            return Ok(exam);
//        }

//        // POST: api/exams
//        [HttpPost]
//        public async Task<ActionResult> Post([FromBody] Exam exam)
//        {
//            if (exam == null)
//            {
//                return BadRequest();
//            }

//            await _examService.AddAsync(exam);
//            return CreatedAtAction(nameof(GetById), new { id = exam.Id }, exam);
//        }

//        // PUT: api/exams/5
//        [HttpPut("{id}")]
//        public async Task<ActionResult> Put(int id, [FromBody] Exam exam)
//        {
//            if (exam == null || exam.Id != id)
//            {
//                return BadRequest();
//            }

//            var existingExam = await _examService.GetByIdAsync(id);
//            if (existingExam == null)
//            {
//                return NotFound();
//            }

//            await _examService.UpdateAsync(exam);
//            return NoContent();
//        }

//        // DELETE: api/exams/5
//        [HttpDelete("{id}")]
//        public async Task<ActionResult> Delete(int id)
//        {
//            var exam = await _examService.GetByIdAsync(id);
//            if (exam == null)
//            {
//                return NotFound();
//            }

//            await _examService.DeleteAsync(id);
//            return NoContent();
//        }
//    }
//}