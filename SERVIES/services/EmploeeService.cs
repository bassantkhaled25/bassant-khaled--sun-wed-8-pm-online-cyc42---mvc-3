using DAL.Entities;
using REPOSITORY.interfaces;
using SERVIES.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVIES.services
{
    public class EmployeeService : IEmployeeService

    {

        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(IUnitOfWork unitOfWork)                //inject (Iunitofwork)
        {

            _unitOfWork = unitOfWork;
        }

        public void Add(Employee entity)

        {
            _unitOfWork.EmploeeRepository.Add(entity);
            _unitOfWork.complete();                                 //savechanges

        }

        public void Delete(Employee entity)
        {
            _unitOfWork.EmploeeRepository.Delete(entity);                    //ممكن اعمل validation ان مينفعش امسح dep فيه ناس
            _unitOfWork.complete();

        }


        public IEnumerable<Employee> GetAll()
        {
            var employees = _unitOfWork.EmploeeRepository.GetAll();
            return employees;
        }

        public Employee GetbyId(int? id)
        {
            var employee = _unitOfWork.EmploeeRepository.GetbyId(id);
            return employee;
        }

        public void Update(Employee entity)
        {

            _unitOfWork.EmploeeRepository.Update(entity);
            _unitOfWork.complete();

        }
    }
}

