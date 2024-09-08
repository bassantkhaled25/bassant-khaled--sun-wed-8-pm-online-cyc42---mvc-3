using AutoMapper;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using REPOSITORY.interfaces;
using REPOSITORY.repositers;
using SERVIES.Helper;
using SERVIES.interfaces;
using SERVIES.ViewModels;
using System.Buffers;

namespace PL.Controllers
{
    public class EmployeeController:Controller

    {
        //private readonly IUnitOfWork _unitOfWork;

        private readonly ILogger<EmployeeController> _logger;                 //console msg
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;                                    //auto mapper
        private readonly IDepartmentService _departmentService;          //list of dep عشان اعمل ال => drop down list


        public EmployeeController(/*IUnitOfWork unitOfWork*/ IEmployeeService employeeService,IMapper mapper, ILogger<EmployeeController> logger, IDepartmentService departmentService)

        {

            //_unitOfWork = unitOfWork;
            _logger = logger;
            _departmentService = departmentService;
            _employeeService = employeeService;
            _mapper = mapper;

        }

        public IActionResult Index(string searchInput)

        {


            if (string.IsNullOrEmpty(searchInput))

            { 

              var emps = _employeeService.GetAll();
              return View(emps);

            }

            else

            {
                var employees = _employeeService.GetEmployeesbyName(searchInput);
                return View(employees);
            }

         
        }


        [HttpGet]
        public IActionResult Create()

        {
            ViewBag.Departments =_departmentService.GetAll();             //drop down list of dep
            return View();

        }

        [HttpPost]

        public IActionResult Create(EmployeeDto employeeDto)           

        {
            /*ModelState["Department"].ValidationState = ModelValidationState.Valid; */      

            if (ModelState.IsValid)

            {
              
               _employeeService.Add(employeeDto);

               return RedirectToAction(nameof(Index));
            }

            else

            {
                return View(employeeDto);
            }

        }

        public IActionResult Details(int? id)

        {
            try

            {

                if (id is null)
                    return BadRequest();

                var employee = _employeeService.GetbyId(id);

                if (employee == null)
                    return NotFound();                                        


                return View(employee);
        
            }

            catch (Exception ex)

            {

                return RedirectToAction("Error", "Home");
            }
        }

        [HttpGet]
        public IActionResult Update(int? id)

        {

            if (id is null)
                return NotFound();

            var employee = _employeeService.GetbyId(id);
            if (employee == null)
                return NotFound();

            return View(employee);

        }

        [HttpPost]
        public IActionResult Update(int id, EmployeeDto employee)

        {
            if (id != employee.Id)
                return NotFound();

         
            if (ModelState.IsValid)                                               //modelstate.is valid => عشان اخليها true عملت ال  dep in entity ب null                   

            {
                try

                {
                    
                    _employeeService.Update(employee);
                    return RedirectToAction(nameof(Index));
                }


                catch (Exception ex)

                {

                    _logger.LogError(ex.Message);

                    return RedirectToAction("Error", "Home");

                }
            }
            return View(employee);

        }

        public IActionResult Delete(int? id)

        {
            

            if (id is null)
                return NotFound();

            var employee = _employeeService.GetbyId(id);    

           
            if (employee == null)
                return NotFound();

          
            else

            {
                _employeeService.Delete(employee);

                return RedirectToAction(nameof(Index));
            }

        }














    }
}
