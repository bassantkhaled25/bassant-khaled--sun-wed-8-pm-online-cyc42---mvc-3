using AutoMapper;
using DAL.Entities;
using REPOSITORY.interfaces;
using SERVIES.Helper;
using SERVIES.interfaces;
using SERVIES.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVIES.services
{
    public class EmployeeService : IEmployeeService                     //logic in service layer 

    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeService(IUnitOfWork unitOfWork,IMapper mapper)                //inject (Iunitofwork + automapper)
        {

            _unitOfWork = unitOfWork;    
            _mapper =mapper;
        }

        public void Add(EmployeeDto employeeDto)                        //كده هيتعامل مع ال Dto 

        {
            //manual mapping

            //Employee employee = new Employee

            //{
            //    Address = employeeDto.Address,
            //    Age = employeeDto.Age,
            //    DepartmentId = employeeDto.DepartmentId,
            //    HiringDate = employeeDto.HiringDate,
            //    Name = employeeDto.Name,
            //    PhoneNumber = employeeDto.PhoneNumber,
            //    Salary = employeeDto.Salary,
            //    ImageUrl = employeeDto.ImageUrl,
            //};
                                                                                             //file ... view (create) زودت فيه حاجه
            employeeDto.ImageUrl = DocumentSettings.UploadFile(employeeDto.Image,"images");

            Employee employee = _mapper.Map<Employee>(employeeDto);        //EmployeeDto => employee

            _unitOfWork.EmploeeRepository.Add(employee);

            _unitOfWork.complete();                                           //savechanges

        }

        public void Delete(EmployeeDto employeeDto)
        {
            //Employee employee = new Employee

            //{
            //    Address = employeeDto.Address,
            //    Age = employeeDto.Age,
            //    DepartmentId = employeeDto.DepartmentId,
            //    HiringDate = employeeDto.HiringDate,
            //    Name = employeeDto.Name,
            //    PhoneNumber = employeeDto.PhoneNumber,
            //    Salary = employeeDto.Salary,
            //    ImageUrl = employeeDto.ImageUrl,
            //};

            Employee employee = _mapper.Map<Employee>(employeeDto);        //EmployeeDto => employee


            _unitOfWork.EmploeeRepository.Delete(employee);               
                                                                          //ممكن اعمل validation ان مينفعش امسح dep فيه ناس
            _unitOfWork.complete();

        }


        public IEnumerable<EmployeeDto> GetAll()             
        {
            var employees = _unitOfWork.EmploeeRepository.GetAll();     //List of emp احوله ل => empDto

            //var mappedemp = employees.Select(x => new EmployeeDto
            //{
            //    DepartmentId = x.DepartmentId,
            //    Name = x.Name,
            //    Age = x.Age,
            //    Address = x.Address,
            //    Salary = x.Salary,
            //    PhoneNumber = x.PhoneNumber,
            //    HiringDate = x.HiringDate,
            //    Email = x.Email,
            //    ImageUrl = x.ImageUrl,
            //    CreatedAt = x.CreatedAt,
            //});

            IEnumerable<EmployeeDto> mappedEmployees=_mapper.Map<IEnumerable<EmployeeDto>>(employees);    //جايلي داتا من ال entity => وعاوز احولها ل employeeDto
            return mappedEmployees;
        }

        public EmployeeDto GetbyId(int? id)
        {

            if (id == null)

                return null;

            var employee = _unitOfWork.EmploeeRepository.GetbyId(id);                   //جايلي employee عاوز احوله ل => empDto

            //EmployeeDto employeeDto = new EmployeeDto

            //{
            //    DepartmentId = employee.DepartmentId,
            //    Name = employee.Name,
            //    Age = employee.Age,
            //    Address = employee.Address,
            //    Salary = employee.Salary,
            //    PhoneNumber = employee.PhoneNumber,
            //    HiringDate = employee.HiringDate,
            //    Email = employee.Email,
            //    ImageUrl = employee.ImageUrl,
            //    CreatedAt = employee.CreatedAt,

            //};

            EmployeeDto employeeDto = _mapper.Map<EmployeeDto>(employee);         //emp=>empDto

            return employeeDto;
        }

        public IEnumerable<EmployeeDto> GetEmployeesbyName(string name)                  //implement from interface
        {
            var employees = _unitOfWork.EmploeeRepository.GetEmployeesbyName(name);

            //var mappedemp = employees.Select(x => new EmployeeDto

            //{
            //    DepartmentId = x.DepartmentId,
            //    Name = x.Name,
            //    Age = x.Age,
            //    Address = x.Address,
            //    Salary = x.Salary,
            //    PhoneNumber = x.PhoneNumber,
            //    HiringDate = x.HiringDate,
            //    Email = x.Email,
            //    ImageUrl = x.ImageUrl,
            //    CreatedAt = x.CreatedAt,
            //});
                                                                                                 //جايلي داتا من ال entity => وعاوز احولها ل employeeDto
            IEnumerable<EmployeeDto> mappedEmployees = _mapper.Map<IEnumerable<EmployeeDto>>(employees); 
           
            return mappedEmployees;

           

        }
        public void Update(EmployeeDto entity)

        {

            //_unitOfWork.EmploeeRepository.Update(entity);
            //_unitOfWork.complete();

        }
    }
}

