using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Model
{
    public class Employee
    {

        [Key]
        public int Id { get; set; }


        [Column(TypeName = "nvarchar(30)")]
        public string Name { get; set; }


        [Column(TypeName = "nvarchar(3)")]
        public string Age { get; set; }


        [Column(TypeName = "nvarchar(9)")]
        public string Salary { get; set; }


    }
}
