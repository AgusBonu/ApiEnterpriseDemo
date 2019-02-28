using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEnterpriseDemo.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("Enterprise")]
        public int EnterpriseId { get; set; }
        [JsonIgnore]
        public Enterprise Enterprise { get; set; }

    }
}
