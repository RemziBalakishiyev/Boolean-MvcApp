using BooleanşMvcApp.Context;
using BooleanşMvcApp.Models;
using BooleanşMvcApp.Tables;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BooleanşMvcApp.Controllers
{
    public class ExamController : Controller
    {
        private readonly BooleanStudentsContext _dbContext;

        public ExamController()
        {
            _dbContext = new BooleanStudentsContext();
        }
        [HttpGet]
        public IActionResult Examines()
        {
            ViewBag.Students = _dbContext.Students.ToDictionary(x => x.Id, x => $"{x.FirstName} {x.LastName}");
            return View();
        }
        [HttpGet]
        public IActionResult GetExamines()
        {
            IEnumerable<ExaminModel> models = _dbContext.ExamineResults
                .Include(x => x.Student)
                .Include(x => x.Subject)
                .Select(x => new ExaminModel
                {
                    Id = x.Id,
                    Result = x.Result!.Value,
                    Student = new StudentModel
                    {
                        FirstName = x.Student!.FirstName,
                        LastName = x.Student.LastName,
                        Id = x.StudentId!.Value
                    },
                    Subject = x.Subject!
                });
            return Json(models);
        }

        [HttpPost]
        public async Task<IActionResult> AddExam([FromBody] ExamAddModel model)
        {
            ExamineResult examineResult = new ExamineResult
            {
                Result = model.Result,
                StudentId = model.StudentId,
                ExamDate = model.ExamDate,
            };

            await _dbContext.ExamineResults.AddAsync(examineResult);
            await _dbContext.SaveChangesAsync();
            return Json("");
        }
    }
}
