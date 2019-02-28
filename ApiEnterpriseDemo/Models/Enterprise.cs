using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEnterpriseDemo.Models
{
    public class Enterprise
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(11111111111, 99999999999)]
        public long Cuit { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
