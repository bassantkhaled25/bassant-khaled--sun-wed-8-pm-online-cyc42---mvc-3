using AutoMapper;
using DAL.contexts;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using REPOSITORY.interfaces;
using SERVIES.interfaces;
using SERVIES.ViewModels;
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
        private readonly IMapper _mapper;

        public DepartmentService(IUnitOfWork unitOfWork , IMapper mapper)      //inject (Iunitofwork)
        {

            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Add(DepartmentDto departmentDto)
        {
            var mappeedDep=_mapper.Map<Department>(departmentDto);       //depDto => dep   source (depDto)=> destination(dep)
            _unitOfWork.DepartmentRepository.Add(mappeedDep);
            _unitOfWork.complete();

        }

       
        public void Delete(DepartmentDto departmentDto)
        {
            var mappeedDep = _mapper.Map<Department>(departmentDto);              //depDto => dep   source (depDto)=> destination(dep)
            _unitOfWork.DepartmentRepository.Delete(mappeedDep);                    //ممكن اعمل validation ان مينفعش امسح dep فيه ناس
            _unitOfWork.complete();
        
        }

        public IEnumerable<DepartmentDto> GetAll()
        {
            var departments = _unitOfWork.DepartmentRepository.GetAll();      //list of dep =>(map to) IEnumrable depDto
            var mappeddep=_mapper.Map<IEnumerable<DepartmentDto>>(departments);
            return mappeddep;
        }

        public DepartmentDto GetbyId(int? id)

        {
            if (id == null)
                return null;

            var department = _unitOfWork.DepartmentRepository.GetbyId(id.Value);      //dep=>depDto


            if (department == null)
                return null;

          var mappeddep = _mapper.Map<DepartmentDto>(department);


            return mappeddep;
        }

      

        public void Update(DepartmentDto departmentDto)

        {
           var department = _mapper.Map<Department>(departmentDto);  
           _unitOfWork.DepartmentRepository.Update(department);
           _unitOfWork.complete();

        }

     
    }
}
