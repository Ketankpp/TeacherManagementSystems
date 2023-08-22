using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeacherManagementSystems.Models;

namespace TeacherManagementSystems.Controllers
{
    public class TeacherController : Controller
    {
        // GET: TeacherController
        public ActionResult Index()
        {
            List<Teacher> lstTeac = Teacher.GetAllTeachers();
            return View(lstTeac);
        }

        // GET: TeacherController/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
                return NotFound();
            Teacher obj = Teacher.GetSingleTeacher(id.Value);
            return View(obj);
        }

        // GET: TeacherController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TeacherController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Teacher obj)
        {
            try
            {
                Teacher.InsertTeacher(obj);
                ViewBag.message = "Success!";
                ModelState.Clear();
                return View(); ;
            }
            catch(Exception ex)
            {
                ViewBag.message = ex.Message;
                return View();
            }
        }

        // GET: TeacherController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return NotFound();
            Teacher obj = Teacher.GetSingleTeacher(id.Value);
            return View(obj);
        }

        // POST: TeacherController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Teacher obj)
        {
            try
            {
                Teacher.UpdateTeacher(obj);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ViewBag.message = ex.Message;
                return View();
            }
        }

        // GET: TeacherController/Delete/5
        public ActionResult Delete(int ?id)
        {
            if (id == null)
                return NotFound();
            Teacher obj = Teacher.GetSingleTeacher(id.Value);
            return View(obj);
        }

        // POST: TeacherController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Teacher obj)
        {
            try
            {
                Teacher.DeleteTeacher(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
