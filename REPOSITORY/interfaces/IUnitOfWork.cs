using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REPOSITORY.interfaces
{
    public interface IUnitOfWork
    {
        public IDepartmentRepository DepartmentRepository { get; set; }      //اي rep هضيفها هنا

        public IEmploeeRepository EmploeeRepository { get; set; }

        int complete();                                                        //method

    }
}
