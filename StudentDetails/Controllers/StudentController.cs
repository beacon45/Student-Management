using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentDetails.Data;
using StudentDetails.Models;
using StudentDetails.Models.Entity;

namespace StudentDetails.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            this._context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View("Add");
        }
        [HttpPost]
        public async Task<IActionResult> Index(AddStudentViewModel studentViewModel)
        {
            var student = new Student
            {
                Name = studentViewModel.Name,
                Email = studentViewModel.Email,
                Phone = studentViewModel.Phone,
                Subscribed = studentViewModel.Subscribed,
            };
            await _context.students.AddAsync(student);
            await _context.SaveChangesAsync();
            return View("Add");
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var std= await _context.students.ToListAsync();
            return View(std);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var std = await _context.students.FindAsync(id);
            return View(std);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Student viewStudent)
        {
            var std = await _context.students.FindAsync(viewStudent.Id);
            if(std != null)
            {
                std.Name = viewStudent.Name;
                std.Email = viewStudent.Email;
                std.Phone = viewStudent.Phone;
                std.Subscribed = viewStudent.Subscribed;

                await _context.SaveChangesAsync();
            }
            return RedirectToAction("List");
        }
    }
}
