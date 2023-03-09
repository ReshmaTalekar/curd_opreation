using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace RBTalekar.Models
{
    public class Employee
    {
        [Key]
        [Required]
        [DisplayName("PRODUCT ID")]
        public int Id { get; set; }
        [Required]
        [DisplayName("PRODUCT NAME")]
        public string Productname { get; set; }
        [Required]
        [DisplayName("CATEGORY ID")]
        public int CategoryId { get; set; }
        [Required]
        [DisplayName("CATEGORY NAME")]
        public string Categoryname { get; set; }
    }
}