using Microsoft.AspNetCore.Mvc;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        StudentRepository studentRepository;


        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            studentRepository = new StudentRepository(configuration);
        }

        public IActionResult Index()
        {
            ViewData["Title"] = "Home Page";
            var students = studentRepository.GetStudents();
            return View(students);
        }
        public IActionResult Add()
        {
            ViewData["Title"] = "Add";
            return View();
        }
        public IActionResult Edit(int id)
        {
            ViewData["Title"] = "Edit";
            var student = studentRepository.GetStudent(id);
            return View(student);
        }
        public IActionResult About()
        {
            ViewData["Title"] = "About";
            return View();
        }

        [HttpPost]
        public IActionResult Add(Student student, IFormFile image)
        {
            ModelState.Remove("image");

            if (!ModelState.IsValid)
            {
                return RedirectToAction("FormAdd");
            }

            if (image != null && image.Length > 0)
            {
                var imageName = Path.GetFileName(image.FileName);
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", imageName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    image.CopyTo(stream);
                }

                student.imageUrl = imageName;
            }
            else
            {
                student.imageUrl = null;
            }

            int ret = studentRepository.Add(student);
            if (ret > 0)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("FormAdd");
        }

        [HttpPost]
        public IActionResult Edit(Student student, IFormFile image)
        {
            ModelState.Remove("image");

            if (!ModelState.IsValid)
            {
                return RedirectToAction("FormEdit", new { id = student.StudentId });
            }

            if (image != null && image.Length > 0)
            {
                var imageName = Path.GetFileName(image.FileName);
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", imageName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    image.CopyTo(stream);
                }

                if (!string.IsNullOrEmpty(student.imageUrl) && student.imageUrl != imageName)
                {
                    var oldPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", student.imageUrl);
                    if (System.IO.File.Exists(oldPath))
                        System.IO.File.Delete(oldPath);
                }

                student.imageUrl = imageName;
            }

            int ret = studentRepository.Edit(student);
            if (ret > 0)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("FormAdd");
        }

        public IActionResult Delete(int id)
        {
            var student = studentRepository.GetStudent(id);

            if (student == null)
            {
                return NotFound();
            }

            if (!string.IsNullOrEmpty(student.imageUrl))
            {
                string deletePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", student.imageUrl);
                if (System.IO.File.Exists(deletePath))
                {
                    System.IO.File.Delete(deletePath);
                }
            }

            studentRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
