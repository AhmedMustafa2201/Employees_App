using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_App.Repository.ViewModels
{
    public class JoinVM
    {
        public string Dep_Name { get; set; }
        public string Emp_Name { get; set; }
        public string Client_Name { get; set; }
    }

    public class Count_Result
    {
        public string Dep_Name { get; set; }
        public int res_num { get; set; }
    }
}
