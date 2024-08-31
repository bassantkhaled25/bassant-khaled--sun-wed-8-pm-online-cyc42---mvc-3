using Microsoft.AspNetCore.Mvc;
using REPOSITORY.interfaces;

namespace PL.Controllers
{
    public class DepartmentController : Controller

    {
        private readonly IDepartmentRepository _departmentRepository;       //injection (IDeptRep) => needs registeration
        public DepartmentController(IDepartmentRepository Deptrepository)

        {
            _departmentRepository = Deptrepository;
        }

       
        public IActionResult Index()                                   //action(index)

        {
            var departments = _departmentRepository.GetAll();
            return View(departments);
        }
    }
}
