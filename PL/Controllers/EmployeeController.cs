using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using REPOSITORY.interfaces;

namespace PL.Controllers
{
    public class EmployeeController:Controller

    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IUnitOfWork _unitOfWork;
       

        public EmployeeController (IUnitOfWork unitOfWork,ILogger<EmployeeController> logger)

        {
            
            _unitOfWork = unitOfWork;
            _logger = logger;
           
        }

        public IActionResult Index()                                           

        {
            var Employees = _unitOfWork.EmploeeRepository.GetAll();

            return View(Employees);                                          //return view + emp
        }

        [HttpGet]
        public IActionResult Create()

        {
            return View();

        }

        [HttpPost]

        public IActionResult Create(Employee employee)

        {
            /*ModelState["Department"].ValidationState = ModelValidationState.Valid; */      

            if (ModelState.IsValid)

            {
                _unitOfWork.EmploeeRepository.Add(employee);
                _unitOfWork.complete();
                return RedirectToAction(nameof(Index));
            }

            else

            {

                return View(employee);
            }



        }

        public IActionResult Details(int? id)

        {
            try

            {

                if (id is null)
                    return BadRequest();

                var employee = _unitOfWork.EmploeeRepository.GetbyId(id);
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

            var employee = _unitOfWork.EmploeeRepository.GetbyId(id);
            if (employee == null)
                return NotFound();

            return View(employee);

        }

        [HttpPost]
        public IActionResult Update(int id, Employee employee)

        {
            if (id != employee.Id)
                return NotFound();

         
            if (ModelState.IsValid)                                               //modelstate.is valid => عشان اخليها true عملت ال  dep in entity ب null                   

            {
                try

                {
                    _unitOfWork.EmploeeRepository.Update(employee);
                    _unitOfWork.complete();
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

            var employee = _unitOfWork.EmploeeRepository.GetbyId(id);

            if (employee == null)
                return NotFound();

            else

            {
                _unitOfWork.EmploeeRepository.Delete(employee);

                _unitOfWork.complete();

                return RedirectToAction(nameof(Index));
            }

        }














    }
}
