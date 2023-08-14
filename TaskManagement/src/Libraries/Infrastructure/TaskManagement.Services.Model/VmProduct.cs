using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Shared;

namespace TaskManagement.Services.Model
{
    public class VmProduct:IVm
    {
     
        public string ProductName {get;set;} = string.Empty;    
        public double ProductPrice{get; set; }
        public string ProductModel {get; set; } = string.Empty;
        public int id { get ; set ; }
    }
}
