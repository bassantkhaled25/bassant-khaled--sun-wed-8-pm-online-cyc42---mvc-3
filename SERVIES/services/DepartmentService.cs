using DAL.Entities;
using Microsoft.EntityFrameworkCore.Diagnostics;
using REPOSITORY.interfaces;
using SERVIES.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVIES.services
{
    public class DepartmentService : IDepartmentService

    {

        private readonly IUnitOfWork _unitOfWork;

        public DepartmentService(IUnitOfWork unitOfWork)      //inject (Iunitofwork)
        {

            _unitOfWork = unitOfWork;
        }

        public void Add(Department entity)
        {
            _unitOfWork.DepartmentRepository.Add(entity);
            _unitOfWork.complete();

        }

        public void Delete(Department entity)
        {
            _unitOfWork.DepartmentRepository.Delete(entity);                    //ممكن اعمل validation ان مينفعش امسح dep فيه ناس
            _unitOfWork.complete();
        
        }


        public IEnumerable<Department> GetAll()
        {
            var departments = _unitOfWork.DepartmentRepository.GetAll();
            return departments;
        }

        public Department GetbyId(int? id)
        {
            var department = _unitOfWork.DepartmentRepository.GetbyId(id);
            return department;
        }

        public void Update(Department entity)
        {

            _unitOfWork.DepartmentRepository.Update(entity);
            _unitOfWork.complete();

        }

    }
}
