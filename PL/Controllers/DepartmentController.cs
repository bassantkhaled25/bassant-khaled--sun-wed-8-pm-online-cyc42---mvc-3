using DAL.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Client;
using REPOSITORY.interfaces;
using SERVIES.interfaces;

namespace PL.Controllers
{
    public class DepartmentController : Controller

    {
        private readonly IUnitOfWork _unitOfWork;                               //inject (unit of work)

        /* private readonly IDepartmentService _departmentService;  */          //inject field (IDeptservice) => needs registeration

        private readonly ILogger<DepartmentController> _logger;                   // + inject (ilogger)

        public DepartmentController (/*IDepartmentService departmentService*/ IUnitOfWork unitOfWork , ILogger<DepartmentController> logger)

        {
            _unitOfWork = unitOfWork;
          
            _logger = logger;

            //_departmentService = departmentService;
        }


        public IActionResult Index()                                            //action(index)

        {
            var departments = _unitOfWork.DepartmentRepository.GetAll();

            return View(departments);                                          //return view + departments
        }



        [HttpGet]                        //1                                  //action (create or add) (get and post)
        public IActionResult Create()

        {
            return View();                                                   //page not working (method not allowed (Get))
        }



        [HttpPost]                        //2             

        public IActionResult Create(Department department)                                  //هبعتله ال dep .. post => بعد ما عملت ال get هيروح ع ديه

        {

            if (ModelState.IsValid)                                                        //validations

            {
                _unitOfWork.DepartmentRepository.Add(department);        // لو اكتر من opeartion هيعمل save مره واحده
                _unitOfWork.complete();                                   //method to save changes
                return RedirectToAction(nameof(Index));                                            //redirect to index page after adding
            }

            else

            {
                return View(department);
            }

        }

        public IActionResult Details(int? id)                                         //deafult(Get) //ببعت ال id  => بتاع ال dep  .. اللي عاوز اجيب الداتا بتاعته

        {
            try
            {

                if (id is null)
                    return BadRequest();                                                   //error 400 (if doesnot send id)

                var department = _unitOfWork.DepartmentRepository.GetbyId(id);                    //if id not found in table

                if (department == null)
                    return NotFound();

                return View(department);

            }

            catch (Exception ex)

            {
                _logger.LogError(ex.Message);

                return RedirectToAction("Error", "Home");                           //controller home (error action))

            }
        }


        [HttpGet]
        public IActionResult Update(int? id)
                                                                                    //form editable
        {

            if (id is null)
                return NotFound();                                              //error 400 (if doesnot send id)

            var department = _unitOfWork.DepartmentRepository.GetbyId(id);                    //if id not found in table

            if (department == null)
                return NotFound();

            return View(department);

        }

        [HttpPost]
        public IActionResult Update(int id, Department department)

        {
            if (id != department.Id)
                return NotFound();


            if (ModelState.IsValid)
            {
                try

                {
                    _unitOfWork.DepartmentRepository.Update(department);
                    _unitOfWork.complete();
                    return RedirectToAction(nameof(Index));
                }


                catch (Exception ex)

                {

                    throw new Exception(ex.Message);

                }
            }
            return View(department);

        }

        public IActionResult Delete(int? id)

        {
            if (id is null)
                return NotFound();                                              //error 400 (if doesnot send id)

            var department = _unitOfWork.DepartmentRepository.GetbyId(id);                    //if id not found in table

            if (department == null)
                return NotFound();

            else

            {
                _unitOfWork.DepartmentRepository.Delete(department);

                _unitOfWork.complete();

                return RedirectToAction(nameof(Index));
            }

        }
    }
}










