using AutoMapper;
using DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Client;
using REPOSITORY.interfaces;
using SERVIES.interfaces;
using SERVIES.services;
using SERVIES.ViewModels;

namespace PL.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DepartmentController : Controller                              

    {
       /* private readonly IUnitOfWork _unitOfWork;  */                             //inject (unit of work)

        private readonly IDepartmentService _departmentService;                    //inject field (IDeptservice) => needs registeration

        private readonly ILogger<DepartmentController> _logger;                     // + inject (ilogger)

        private readonly IMapper _mapper;

        public DepartmentController (IDepartmentService departmentService , /*IUnitOfWork unitOfWork ,*/ ILogger<DepartmentController> logger , IMapper mapper)

        {
            //_unitOfWork = unitOfWork;

            _departmentService = departmentService;
          
            _logger = logger;
          
            _mapper =mapper;

        
        }


        public IActionResult Index()                                            //action(index)

        {
            var departments = _departmentService.GetAll();
           
            return View(departments);


                                                                             //return view + departments
        }
    


        [HttpGet]                                                        //action (create or add) (get and post)
        public IActionResult Create()

        {
            return View();                                                   //page not working (method not allowed (Get))
        }



        [HttpPost]                        
        public IActionResult Create(DepartmentDto department)                                  //هبعتله ال dep .. post => بعد ما عملت ال get هيروح ع ديه

        {

            if (ModelState.IsValid)                                                        //validations

            {
                
                _departmentService.Add(department);     
                                               
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

                var department = _departmentService.GetbyId(id);                    //if id not found in table

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

            var department = _departmentService.GetbyId(id);                    //if id not found in table

            if (department == null)
                return NotFound();

            return View(department);

        }

        [HttpPost]
        public IActionResult Update(DepartmentDto department)         //id hidden in view

        {
            if (department.Id == null)                        
                return NotFound();


            if (ModelState.IsValid)
            {
                try

                {

                    _departmentService.Update(department);
                   
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

            var department = _departmentService.GetbyId(id);                    //if id not found in table

            if (department == null)
                return NotFound();

            else

            {
                _departmentService.Delete(department);

                return RedirectToAction(nameof(Index));
            }

        }
    }
}










