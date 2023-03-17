using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using STAFFS.DAL;
using STAFFS.Models;

namespace STAFFS.Controllers
{
    public class StaffsController : Controller
    {
        private readonly StaffsDAL _dal;
        public StaffsController(StaffsDAL dal)
        {
            _dal = dal;
        }


        // GET: StaffsController
        public IActionResult Index()
        {
            List<Staffs> staffs = new List<Staffs>();
            staffs = _dal.GetAll();
            return View(staffs);
        }

        // GET: StaffsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StaffsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StaffsController/Create
        [HttpPost]
        public IActionResult Create(Staffs staffs)
        {
            try
            {
                bool result = _dal.Insert(staffs);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

                return View();
            }
        }

        // GET: StaffsController/Edit/5
        public IActionResult Edit(int id)
        {
            Staffs staffs = _dal.GetById(id);
            return View(staffs);
        }

        // POST: StaffsController/Edit/5
        [HttpPost]
        public IActionResult Edit(Staffs staffs)
        {
            bool result = _dal.Update(staffs);
            return RedirectToAction("Index");
        }

        // GET: StaffsController/Delete/5
        public IActionResult Delete(int id)
        {
            Staffs staffs = _dal.GetById(id);
            return View(staffs);
        }

        // POST: StaffsController/Delete/5
        [HttpPost]
        public IActionResult Delete(Staffs staffs)
        { 
            bool result = _dal.Delete(staffs.Id);
            return RedirectToAction("Index");
        }
    }
}
