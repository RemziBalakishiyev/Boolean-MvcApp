using BooleanşMvcApp.Context;
using BooleanşMvcApp.Models;
using BooleanşMvcApp.Tables;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BooleanşMvcApp.Controllers
{
    public class StudentController : Controller
    {
        private readonly BooleanStudentsContext _dbContext;
        public StudentController()
        {
            _dbContext = new BooleanStudentsContext();
        }
        public async Task<IActionResult> Home()
        {
            var students = await _dbContext.Students
                  .Select(x => new StudentModel
                  {
                      Id = x.Id,
                      FirstName = x.FirstName,
                      LastName = x.LastName,
                  }
                  ).ToListAsync();

            return View(students);
        }

        public IActionResult StudentDetail(int id)
        {
            var student = _dbContext.Students
                .Include(x => x.Gender)
                .Include(x => x.StudentDetail)
                .Select(x => new StudentDetailModel
                {
                    Id = x.Id,
                    FullName = $"{x.FirstName} {x.LastName}",
                    Gender = x.Gender!.Name ?? "No Gender",
                    StudentDetail = x.StudentDetail!
                })
                .FirstOrDefault(x => x.Id == id);
            return View(student);
        }


        public async Task<IActionResult> StudentList()
        {
            var students = await _dbContext.Students
                .Include(x => x.StudentDetail)
                .Include(x => x.Gender)
                .Include(x=>x.Group)
                .AsNoTracking()
                .Select(x => new StudentDetailModel
                {
                    Id = x.Id,
                    FullName = $"{x.FirstName} {x.LastName}",
                    Gender = x.Gender!.Name ?? "No Gender",
                    GroupName = x.Group!.Name,
                    StudentDetail = x.StudentDetail ?? new StudentDetail()
                })
                .OrderByDescending(x=>x.Id)
                .ToListAsync();
            return View(students);
        }

        [HttpGet]
        public IActionResult AddNewStudent()
        {
            var groups = _dbContext.Groups
                .AsNoTracking()
                .ToDictionary(x => x.Id, x => x.Name);

            var genders = _dbContext.Genders
                .AsNoTracking()
                .ToDictionary(x => x.Id, x => x.Name);

            ViewBag.Genders = genders;
            ViewBag.Groups = groups;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewStudent(StudentAddModel model)
        {
            var groups = _dbContext.Groups
               .AsNoTracking()
               .ToDictionary(x => x.Id, x => x.Name);

            var genders = _dbContext.Genders
                .AsNoTracking()
                .ToDictionary(x => x.Id, x => x.Name);

            ViewBag.Genders = genders;
            ViewBag.Groups = groups;
            if (ModelState.IsValid)
            {

                Student student = new()
                {
                    Id = model.Id,
                    DateOfBirth = model.DateOfBirth,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Patronymic = model.Patronymic,
                    GenderId = model.GenderId,
                    GroupId = model.GroupId,
                    StudentDetail = new StudentDetail
                    {
                        AcceptPoint = model.AcceptPoint,
                        BirthPlace = model.BirthPlace,
                    }
                };

                await _dbContext.Students.AddAsync(student);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction("StudentList");
            }
            return View(model);
        }
    }
}
