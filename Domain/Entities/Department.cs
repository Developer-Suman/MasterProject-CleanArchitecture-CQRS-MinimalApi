using Domain.Premetives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public sealed class Department : CustomEntity
    {
        public Department(int id, string? departmentNameInNepali, string? departmentNameInEnglish ) : base(id)
        {
            DepartmentNameInNepali = departmentNameInNepali;
            DepartmentNameInEnglish = departmentNameInEnglish;
        }

        public string? DepartmentNameInNepali { get; set; }
        public string? DepartmentNameInEnglish { get; set;}
    }
}
